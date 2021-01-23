    int[][] items = { 
                        new[] { 11001, 54010, 60621 },
                        new[] { 11001, 60621 },
                        new[] { 60621 }
                    };
    var routes = CartesianProduct(items);
    foreach (var route in routes)
        Console.WriteLine(string.Join(", ", route));
