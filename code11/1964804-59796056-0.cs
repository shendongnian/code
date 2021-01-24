    using System;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var emptyStringConverter = new EmptyStringConverter();
                emptyStringConverter.Write(null, null, null);
            }
        }
    }
