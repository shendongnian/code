    public base
    {
        public string Name { get; set; }
    }
    public derived : base
    {
    }
    derived d = new derived();
    d.Name = "Test";
    base b = d as base;
    print b.Name;
