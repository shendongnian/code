    [Table]
    public class Content
    {
        ...
        private EntitySet<Page> _pges;
        [Association(Storage = "_pages", ThisKey = "Id", OtherKey = "ContentId")]
        public EntitySet<Page> Pages
        {
            get { return _page; }
            set { _pages.Assign(value); }
        }
        ...
    }
