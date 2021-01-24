        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        
        [NotMapped] //This is not mapped on the operational DB
        public string DatabaseAction { get; set; }
    }
    ```
