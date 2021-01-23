    var extendedObject = MyMethod(
        new {
            FirstProperty = "abcd",
            SecondProperty = 100
        }
    );
    var casted = CastByExample(
        extendedObject,
        new {
            FirstProperty = "abcd",
            SecondProperty = 100,
            AddedProperty = true 
        }
    );
    Console.WriteLine(xyz.AddedProperty);
