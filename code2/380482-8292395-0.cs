    static void Main(string[] args)
    {           
        int val;            
        Console.WriteLine("Please enter a number!");
        val = Int32.Parse(Console.ReadLine());                                 
        for (int i = val; i <= (val + 10); i++)
          Console.WriteLine(i);            
        Console.ReadLine();         
    }
