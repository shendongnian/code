    class Program
    {
        enum Example1 { a, b }
        enum Example2 { one, two }
    
        static void Main()
        {
            PrintEnumValues(default(Example1));
            PrintEnumValues(default(Example2));
        }
    
        static void PrintEnumValues(Enum e) 
        {
            foreach (var item in Enum.GetValues(e.GetType()))
    	    {
                Console.WriteLine(item);		 
    	    }
        }
    }
