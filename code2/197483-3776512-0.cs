    class MyClass {
        readonly Dictionary<string, object> _myProperties =
            new Dictionary<string, object>
            {
                { "Name", "Mark" },                     // type string
                { "Age", 22 },                          // type int
                { "Birthdate", new DateTime(...) },     // type DateTime
            };
    }
