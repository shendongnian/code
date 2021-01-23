    Integer x = 10;
    
    Something t = new Something();
    t.Integer = x;
    
    t.Integer.Value += 1; // This actually won't compile; but if it did,
                          // it would be modifying a copy of t.Integer, leaving
                          // the actual value at t.Integer unchanged.
    
    Console.WriteLine(t.Integer.Value); // would still output 10
