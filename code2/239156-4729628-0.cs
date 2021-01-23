        public class DirectoryListing
        {
            [PrimaryKey, Identity]
            public Int64 Id { get; set; }
            public Int64? OldId { get; set; }
            public Int32 CategoryId { get; set; }
            [Nullable]
            public String CompanyName { get; set; }
    }
