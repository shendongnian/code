    [Required(ErrorMessage="Please enter how many Stream Entries are displayed per page.")]
        [Range(0,250, ErrorMessage="Please enter a number between 0 and 250.")]
        [Column]
        [DataAnnotationsExtensions.Integer(ErrorMessage="Please enter a valid number.")]
        public int StreamEntriesPerPage { get; set; }
