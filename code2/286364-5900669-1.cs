    string name = String.empty
    do
    {
      Console.WriteLine("Enter Student Name : ");
      name = Console.ReadLine()
    }
    while(!Regex.Match(name, "^([A-Za-z ]+)$").Success);
