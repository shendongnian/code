    double nbSteps = 3.0;
    
    IEnumerable<double> SystemA = Enumerable.Range (0, (int)nbSteps).Select (x => x / nbSteps); 
    IEnumerable<double> SystemB = Enumerable.Range (0, (int)nbSteps).Select (x => x / nbSteps); 
    
    var Result = from a in SystemA from b in SystemB select new { a, b };
