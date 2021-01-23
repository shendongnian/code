        [MetadataType(typeof(UserAccountAnnotations))]
        public partial class UserAccount : IDomainEntity
            {
            [Key]
            public int Id { get; set; } // Unique ID
            sealed class UserAccountAnnotations
                {
                [Index("IX_UserName", unique: true)]
                public string UserName { get; set; }
                }
           }
