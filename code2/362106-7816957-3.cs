    [Table]
    public class Content
    {
        ...
        [Column]
        int PageId{ get; set; }
        EntityRef<Page> _page;
        [Association(Storage = "_page", ThisKey = "PageId", OtherKey = "Id", IsForeignKey = true)]
        public Page Page
        {
            get { return _page.Entity; }
            set { _page.Entity = value; }
        }
     }
