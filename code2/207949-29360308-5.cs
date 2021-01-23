    class sample
    {
        public int x;
    
        public sample(int value)
        {
            x = value;
        }
    }
    
    class der : sample
    {
        public int a;
        public int b;
    
        public der(int value1,int value2) : base(50)
        {
            a = value1;
            b = value2;
        }
    }
     
    class run 
    {
        public static void Main(string[] args)
        {
            der obj = new der(10,20);
       
            System.Console.WriteLine(obj.x);
            System.Console.WriteLine(obj.a);
            System.Console.WriteLine(obj.b);
    	}
    }
