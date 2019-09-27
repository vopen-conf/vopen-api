﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vopen_api.Data
{
    [Table("Editions")]
    public class Edition // e.g vOpen AR 2019 (being vOpen the Event)
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public ICollection<EditionDetail> Details { get; set; }

        [Required]
        public Event Event { get; set; }

        public string LocationName { get; set; }

        public string LocationFullAddress { get; set; }

        public ICollection<EditionTicket> EditionTickets { get; set; }

        [Required]
        public ICollection<EditionOrganizer> Organizers { get; set; }

        [Required]
        public ICollection<EditionSponsor> Sponsors { get; set; }

        [Required]
        public ICollection<EditionActivity> Activities { get; set; }

        public Edition()
        {
            this.Details = new List<EditionDetail>();
            this.EditionTickets = new List<EditionTicket>();
            this.Organizers = new List<EditionOrganizer>();
            this.Sponsors = new List<EditionSponsor>();
            this.Activities = new List<EditionActivity>();
        }
    }

    [Table("EditionsDetails")]
    public class EditionDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("EditionId")]
        public Edition Edition { get; set; }

        [Required]
        public string Language { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Date { get; set; }
    }

    [Table("EditionsTickets")]
    public class EditionTicket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("EditionId")]
        public Edition Edition { get; set; }

        [Required]
        public string Name { get; set; }

        public string Price { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string BuyLinks { get; set; }
    }

    [Table("EditionsOrganizers")]
    public class EditionOrganizer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("EditionId")]
        public Edition Edition { get; set; }

        [Required]
        public User User { get; set; }
    }

    [Table("EditionsSponsors")]
    public class EditionSponsor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("EditionId")]
        public Edition Edition { get; set; }

        [Required]
        [ForeignKey("SponsorId")]
        public Sponsor Sponsor { get; set; }

        [Required]
        public string Type { get; set; }
    }

    [Table("EditionsActivities")]
    public class EditionActivity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("EditionId")]
        public Edition Edition { get; set; }

        [Required]
        public ICollection<EditionActivityDetail> Details { get; set; }
        
        [Required]
        public ICollection<EditionActivityUser> Users { get; set; }

        [Required]
        public ICollection<EditionActivityScore> Scores { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Day { get; set; }

        [Required]
        public string Track { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        public string Tags { get; set; }

        [Required]
        public string Level { get; set; }

        public EditionActivity()
        {
            this.Details = new List<EditionActivityDetail>();
            this.Users = new List<EditionActivityUser>();
            this.Scores = new List<EditionActivityScore>();
        }
    }

    [Table("EditionsActivitiesDetails")]
    public class EditionActivityDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("EditionActivityId")]
        public EditionActivity EditionActivity { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }

    [Table("EditionsActivitiesUsers")]
    public class EditionActivityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("EditionActivityId")]
        public EditionActivity EditionActivity { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }
    }

    [Table("EditionsActivitiesScores")]
    public class EditionActivityScore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("EditionActivityId")]
        public EditionActivity EditionActivity { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [Required]
        public double Score { get; set; }

        public string Comments { get; set; }
    }
}
