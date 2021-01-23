    string line = Console.ReadLine();
    
    if(new Regex(@"^\d+\s+\d+$").IsMatch(line))
    {
       ...   // Valid: process input
    }
    else
    {
       ...   // Invalid input
    }
