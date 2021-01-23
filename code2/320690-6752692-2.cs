        public class Sites
        {
            [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int SiteID { get; set; }
            public string Name { get; set; }
            public string Tags { get; set; }
            public string Description { get; set; }
            public string URI { get; set; }
        }
