    class MyList : List<int>
    {
        public string Text { get; set; }
        public MyList Values { get { return this; } }
    }
