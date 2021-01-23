            public class Content
            {
                [Key]
                public int PostId { get; set; }
                public virtual Post Post { get; set; }
                public string FullContent { get; set; }
            }
