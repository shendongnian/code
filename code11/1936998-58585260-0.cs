    public class ServiceProvider
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public double YearsOfExperiance { get; set; }
            public double AverageRank { get; set; }
            public string Nationality { get; set; }
            public ICollection<JobImage> JobImages { get; set; }
            public ICollection<Review> Reviews { get; set; }
            public ICollection<Rank> Ranks { get; set; }
            public bool Active { get; set; }    
            public int CategoryId { get; set; }
            [ForeignKey("CategoryId")]
            public Category Category { get; set; }
    
            public bool Approved { get; set; }
    }
