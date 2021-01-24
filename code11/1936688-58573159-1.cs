    var users = new Dictionary<int, Transformable>
    {
         new Assistant { Name = "Joe" },
         new Professor { Name = "John" },
         new Assistant { Name = "Jane" }
    };
    var assistants = users.Values.OfType<Assistant>().Where(a => a.Name == "Jane");
