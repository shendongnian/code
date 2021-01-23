    var input = new List<string>();
    input.Add("Foo"); // I'd go for splitting by delimiters as well
    input.Add("Bar");
    input.Add("Foo");
    var results = input.Distinct(); // -> Foo, Bar
