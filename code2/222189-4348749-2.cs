    double[] minus = new double[]
    {
        3, 24, 26, 23, 25, 18, 5,  5,  1, 10,
    };
    double[] plus = new double[]
    {
        3,  8,  9, 11, 22, 25, 5,  5,  3, 7
    };
    
    var collisionsBetweenIndices =
    Enumerable.Range(1, minus.Length - 1)
              .Where(i => ((minus[i - 1] - plus[i - 1] < 0) && (minus[i] - plus[i] > 0)) ||
                          ((minus[i - 1] - plus[i - 1] > 0) && (minus[i] - plus[i] < 0)) ||
                          ((minus[i - 1] - plus[i - 1] == 0) && (minus[i] - plus[i] == 0)))
              .ToArray();
    
    var collisionsOnIndices =
    Enumerable.Range(0, minus.Length)
              .Where(i => minus[i] == plus[i])
              .ToArray();
    
    foreach (var idx in collisionsBetweenIndices)
        Console.WriteLine("Collision between {0} and {1}", idx - 1, idx);
    
    foreach (var idx in collisionsOnIndices)
        Console.WriteLine("Collision on {0}", idx);
    // RESULTS:
    // Collision between 4 and 5
    // Collision between 6 and 7
    // Collision between 8 and 9
    // Collision on 0
    // Collision on 6
    // Collision on 7
