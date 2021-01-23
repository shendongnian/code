    [Table]
    public class Page
    {
        ...
        private EntitySet<Content> _contents;
        [Association(Storage = "_contents", ThisKey = "Id", OtherKey = "PageId")]
        public EntitySet<Content> Contents
        {
            get { return _contents; }
            set { _contents.Assign(value); }
        }
        ...
    }
