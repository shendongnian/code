    public BaseClass
    {
        public string Name { get; set; }
    }
    public DerivedClass : BaseClass
    {
    }
    DerivedClass d = new DerivedClass();
    d.Name = "Test";
    BaseClass b = d as BaseClass;
    print b.Name;
