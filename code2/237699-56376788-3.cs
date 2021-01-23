     class Foo
    {
        [Browsable(false)]
        public string Bar { get; set; }
    }
    void Example()
    {
        SetBrowsableAttributeOfAProperty<Foo>("Bar", true);     //works
        Foo foo = new Foo();
        SetBrowsableAttributeOfAProperty(foo, "Bar", false);    //works
        List<Foo> foos = new List<Foo> { foo, new Foo { Bar = "item2" } };
        SetBrowsableAttributeOfAProperty(foos, "Bar", true);    //works now, whereas it would crash with an exception in John Cummings's solution
    }
