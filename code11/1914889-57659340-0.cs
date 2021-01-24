    [TableName("BlogComments")]
        [PrimaryKey("Id", AutoIncrement = true)]
        [ExplicitColumns]
        public class BlogCommentSchema
        {
            [PrimaryKeyColumn(AutoIncrement = true, IdentitySeed = 1)]
            [Column("Id")]
            public int Id { get; set; }
    
            [Column("BlogPostUmbracoId")]
            public int BlogPostUmbracoId { get; set; }
    
            [Column("Name")]
            public string Name { get; set; }
    
            [Column("Email")]
            public string Email { get; set; }
    
            [Column("Website")]
            public string Website { get; set; }
    
            [Column("Message")]
            [SpecialDbType(SpecialDbTypes.NTEXT)]
            public string Message { get; set; }
        }
    }
