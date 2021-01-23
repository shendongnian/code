    class Program
    {
        static void Main(string[] args)
        {
            string stat = "This is an example of code" + "This code has written in C#\n\n";
            Console.Write(stat); 
            char[] myArrayofChar = stat.ToCharArray();
            Array.Reverse(myArrayofChar);
          
            foreach (char myNewChar in myArrayofChar)
                Console.Write(myNewChar);            // Yuo just need to write the function Write instead of WriteLine
            Console.ReadKey();
        }
    }
