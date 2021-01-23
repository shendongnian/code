    public void Main()
    {
    	MyObj a = new MyObj{ integer= 1};
        MyObj b = a;
        
        Console.WriteLine(a.integer); //1
        Console.WriteLine(b.integer);//1
        
        b.integeter = 42;
        
        Console.WriteLine(a.integer);//1
        Console.WriteLine(b.integer);//42
    }
    
    public struct MyObj
    {
        public int integer{get; set;}
    }
