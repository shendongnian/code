    // execute an anonymous delegate (method) for each of the new anonymous objects
    subset.ForEach
    (
       basicObject =>
       {
          Console.WriteLine("Property1 - {0}", basicObject.Property1);
          Console.WriteLine("Property2 - {0}", basicObject.Property2);
          Console.WriteLine("Property3 - {0}", basicObject.Property3);
       }
    );
    // grab the first object off the list
    var firstBasicObject = subset.First();
    // sort the anonymously typed list
    var sortedSubset = subset.OrderBy(a => a.Property1).ToList();
