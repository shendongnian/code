    static void Test() <---- remove the name parameter
    {
        bool exit = true;
        string answer = "";
    
        do
        {
          Console.Write("Please enter your name: ");
          string name = Console.ReadLine().ToLower();     <--- read name here
