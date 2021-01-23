        public class KeyDate
        {
            public KeyDate()
            {
                // create this list
                this.Associations = new List<Association>();
            }
            [Key]
            public int KeyID { get; set; }
            [StringLength(1000), Required]
            public string Title { get; set; }
            [Required]
            public string Description { get; set; }
            [Required]
            [Display(Name = "Event Date")]
            public DateTime EventDate { get; set; }
            [Display(Name = "Event End Date")]
            public DateTime? EventEndDate { get; set; }
            [Display(Name = "Course ID")]
            public int? CourseID { get; set; }
            [Display(Name = "Event ID")]
            public int? EventID { get; set; }
            public DateTime Created { get; set; }
            [Display(Name = "Created By")]
            public string CreatedBy { get; set; }
            public DateTime? Deleted { get; set; }
            [Display(Name = "Deleted By")]
            public string DeletedBy { get; set; }
            public virtual ICollection<Association> Associations { get; set; }
        }
