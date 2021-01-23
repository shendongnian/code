    interface IHasTitle
    {
        string Title { get; }
    }
    class MyType1 : Type1, IHasTitle
    {
        public string IHasTitle.Title { get { return this.title.Text; } }
    }
    class MyType2 : Type2, IHasTitle
    {
        public string IHasTitle.Title { get { return this.Title; } }
    }
