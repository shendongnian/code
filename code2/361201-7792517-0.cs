	[DataType(DataType.Time)]
        public DateTime? SomeDate { get; set; }
        [StringLength(500, ErrorMessage = "This field may not be longer than 500 characters.")]
        public string LongText{ get; set; }
    }
