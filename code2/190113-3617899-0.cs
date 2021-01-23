       public IObjectSet<Blog> Blogs
        {
            get
            {
                return _blogs ?? (_blogs = new FakeObjectSet<Blog>());
            }
            set
            {
                _blogs = value as FakeObjectSet<Blog>;
            }
        }
        private FakeObjectSet<Blog> _blogs;
