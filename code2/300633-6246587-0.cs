    Console.WriteLine("Enter values separated by space");
    string input = Console.ReadLine();
    string[] inputs = input.Split(' ');
    foreach (string inp in inputs)
    {
         Console.WriteLine(inp);  
    }
