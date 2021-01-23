    [Table]
    public class Page
    {
        ...
        [Column]
        int ContentId{ get; set; }
        EntityRef<Content> _content;
        [Association(Storage = "_content", ThisKey = "ContentId", OtherKey = "Id", IsForeignKey = true)]
        public Content Content
        {
            get { return _content.Entity; }
            set { _content.Entity = value; }
        }
     }
