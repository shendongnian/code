    class MyBaseClass
    {
        public int Level { get; set; }
    }
    class MyDerivedClass : MyBaseClass
    {
        public int Points
        {
            get { return this.Level; }
            set { this.Level = value; }
        }
    }
