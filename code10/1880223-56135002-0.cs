    using System;
    
    class Program
    {
        static string field;
        
        static void Main()
        {
            field = "initial value";
            Console.WriteLine($"Before Modify1: {field}");
            
            Modify1(field, "new value for Modify1");
            Console.WriteLine($"After Modify1: {field}");
            
            Modify2(ref field, "new value for Modify2");
            Console.WriteLine($"After Modify2: {field}");
        }
        
        static void Modify1(string storage, string value)
        {
            // This only changes the parameter
            storage = value; 
        }
    
        static void Modify2(ref string storage, string value)
        {
            // This changes the variable that's been passed by reference,
            // e.g. a field
            storage = value;
        }        
    }
