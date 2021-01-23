    // Create some random double values from 0 - 100
    var values = Enumerable.Repeat(new Random(), int.MaxValue)
                           .Select(r => r.NextDouble() * 100);
    //Create an enumeration with ten elements
    var pointList = values.Take(10)
                          //Cause of lacking support of IEnumerable.Zip() or .Pairwise()
                          //use this approach to create something with the properties X and Y
                          .Select(n => new PointF((float)n, (float)values.First()));
    //Sort the elements
    var sortedPoints = pointList.OrderBy(point => point.X);
    //Output to console
    foreach (var point in sortedPoints)
    {
        Console.WriteLine(point.ToString());
    }
