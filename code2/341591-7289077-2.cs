    public ViewResult Index()
    {
        //var foos = db.Foos;
        var foos = new List<Foo>();
        foos.Add(new Foo { Name = "Foo1" });
        foos.Add(new Foo
        {
            Name = "Foo2",
            Lookup = new Lookup
            {
                Name = "Lookup2",
                Description = new Description
                {
                    English = "englishFoo2",
                    French = "frenchFoo2"
                }
            }
        });
        foos.Add(new Foo
        {
            Name = "Foo3",
            Lookup = new Lookup
            {
                Name = "Lookup3",
                Description = new Description
                {
                    //English = "englishFoo3",
                    French = "frenchFoo3"
                }
            }
        });
        foos.Add(new Foo { Name = "Foo4" });
        foos.Add(new Foo
        {
            Name = "Foo5",
            Lookup = new Lookup
            {
                Description = new Description
                {
                    English = "englishFoo5",
                    French = "frenchFoo5"
                }
            }
        });
        foos.Add(new Foo { 
            Name = "Foo6",
            Lookup = new Lookup
            {
                Name = "Lookup6"
            }
        }); 
        return View(foos);
    }
