    public UpdateViewView
    {
        [Required]
        public Guid? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public bool? IsApproved { get; set; }
        //... some other properties
    }
