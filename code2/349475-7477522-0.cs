    public void Main()
    {
    	MyObj a = new MyObj{ integeter = 1};
        MyObj b = a;
        
        Console.WriteLine(a.integeter); //1
        Console.WriteLine(b.integeter);//1
        
        b.integeter = 42;
        
        Console.WriteLine(a.integeter);//1
        Console.WriteLine(b.integeter);//42
    }
    
    // Define other methods and classes here
    public struct MyObj
    {
        public int integeter{get; set;}
    }
