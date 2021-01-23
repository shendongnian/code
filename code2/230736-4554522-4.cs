    interface IHasTitle
    {
        string Title { get; }
    }
    class MyType1 : Type1, IHasTitle
    {
        // Add constructors here.
        public string Title { get { return this.title.Text; } }
    }
    class MyType2 : Type2, IHasTitle
    {
        // Add constructors here.
    }
