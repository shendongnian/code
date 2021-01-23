    Dictionary<string, double[]> doubleArrays = new Dictionary<string, double[]>();
    
    doubleArrays.Add("a", new double[] { 1.0, 1.2 });
    // etc.
    double[] someArray = doubleArrays["a"];
