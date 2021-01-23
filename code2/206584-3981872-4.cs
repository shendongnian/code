    Integer x = new Integer { Value = 10 };
    
    Something t1 = new Something();
    t1.Integer = x;
    
    Something t2 = new Something();
    t2.Integer = t1.Integer;
    
    t1.Integer.Value += 1;
    
    Console.WriteLine(t2.Integer.Value); // Would output 11
