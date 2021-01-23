    List<FooProjection> fooProjections = new List<FooProjection>();
    foreach (var foo in foos)
        foreach (var pew in foo.PewPews)
        {
            fooProjections.Add(new FooProjection()
            {
                Id = foo.Id,
                Name = foo.Name,
                PewPewName = pew.Name,
                PewPewWhatever = pew.Whatever
            });
        }
