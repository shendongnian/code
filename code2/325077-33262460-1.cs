        [Required(ErrorMessage = "Please enter year")]
        [PermittedYearRange]
        public int Year { get; set; }
        [Required(ErrorMessage = "Please enter day")]
        [Range(1, 31, ErrorMessage = "Day must be between 1 and 31")]
        public int Day { get; set; }
        [Required(ErrorMessage = "Please enter month")]
        [Range(1, 31, ErrorMessage = "Month must be between 1 and 12")]
        public int Month { get; set; }
