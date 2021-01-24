    ...
    var itemToAdd = new ClassWithTitle { Title = "Title 1"};
    list.AddOrUpdate(itemToAdd , x => x.Title, (destination, origin) =>
    {
        //Logic to map fields
        destination.Title = origin.Title;
        destination.SomeOtherField = origin.SomeOtherField;
    })
    ...
