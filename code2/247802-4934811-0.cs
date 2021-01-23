    static void WriteObject(object obj) { Console.WriteLine("Object"); }
    static void WriteObject(string str) { Console.WriteLine("String"); }
    
    object obj = "I am a string.";
    WriteObject(obj);
