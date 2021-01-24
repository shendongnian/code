    var users = new Dictionary<int, Transformable>
    {
         {0, new Assistant { Name = "Joe" }},
         {1, new Professor { Name = "John" }},
         {2, new Assistant { Name = "Jane" }}
    };
    var assistants = users.Values.OfType<Assistant>().Where(a => a.Name == "Jane");
