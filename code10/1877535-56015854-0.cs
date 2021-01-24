    public class Keyword
        {
            public Keyword() { }
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int KeywordId { get; set; }
            public int? UserId { get; set; }
            [ForeignKey("UserId")]
            public IdentityUser User { get; set; }
            public string Value { get; set; }
            [Timestamp]
            public byte[] RowVersion { get; set; }
        }
