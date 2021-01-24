           static void Main(string[] args)
            {
                WriteStringToConsole("test"); // OK, temporary variable created.
                string test = "test";
                WriteStringToConsole(test); // OK, temporary int created with the value 0
                WriteStringToConsole(in test); // passed by readonly reference, explicitly using `in`
                //Not allowed
                WriteStringToConsole(in "test"); //Error CS8156  An expression cannot be used in this context because it may not be passed or returned by reference
    
            }
            static void WriteStringToConsole(in string argument)
            {
                Console.WriteLine(argument);
            }
    
            
