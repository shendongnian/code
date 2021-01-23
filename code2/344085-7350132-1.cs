    static void Main(string[] args)
    {
        int i = 0;
                            
        double d = 5900.00; 
        string s = "5900.00";
        Console.WriteLine("Testing with dVal = {0} and sVal = {1}.", d, s);
        i = getDecimalCount(d, s);
        Console.WriteLine("Expected output: 2. Actual output: {0}", i);
        Console.WriteLine();
    
        d = 5900.09;
        s = "5900.09";
        Console.WriteLine("Testing with dVal = {0} and sVal = {1}.", d, s);
        i = getDecimalCount(d, s);
        Console.WriteLine("Expected output: 2. Actual output: {0}", i);
        Console.WriteLine();
    
        d = 5900.000;
        s = "5900.000";
        Console.WriteLine("Testing with dVal = {0} and sVal = {1}.", d, s);
        i = getDecimalCount(d, s);
        Console.WriteLine("Expected output: 3. Actual output: {0}", i);
        Console.WriteLine();
    
        d = 5900.001;
        s = "5900.001";
        Console.WriteLine("Testing with dVal = {0} and sVal = {1}.", d, s);
        i = getDecimalCount(d, s);
        Console.WriteLine("Expected output: 3. Actual output: {0}", i);
        Console.WriteLine();
                
        d = 1.0; 
        s = "1.0";
        Console.WriteLine("Testing with dVal = {0} and sVal = {1}.", d, s);
        i = getDecimalCount(d, s);
        Console.WriteLine("Expected output: 1. Actual output: {0}", i);
        Console.WriteLine();
    
        d = 0.0000005; 
        s = "0.0000005";
        Console.WriteLine("Testing with dVal = {0} and sVal = {1}.", d, s);
        i = getDecimalCount(d, s);
        Console.WriteLine("Expected output: 7. Actual output: {0}", i);
        Console.WriteLine();
    
        d = 1.0000000; 
        s = "1.0000000";
        Console.WriteLine("Testing with dVal = {0} and sVal = {1}.", d, s);
        i = getDecimalCount(d, s);
        Console.WriteLine("Expected output: 7. Actual output: {0}", i);
        Console.WriteLine();
    
        d = 5900822; 
        s = "5900822";
        Console.WriteLine("Testing with dVal = {0} and sVal = {1}.", d, s);
        i = getDecimalCount(d, s);
        Console.WriteLine("Expected output: 0. Actual output: {0}", i);
    
        Console.ReadLine();
    }
