    static void Main(string[] args)
    { 
        int i=0;
        string str=String.Empty;
        Char c;            
        Console.WriteLine("Enter number:");
        while (i < 10)
        {
           if (char.IsDigit(c = Console.ReadKey().KeyChar))
           {
                str += c;
                i++;
           }
        }
        Console.WriteLine("str: "+str); 
    }
