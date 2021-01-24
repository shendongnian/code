    Console.InputEncoding = Encoding.Unicode;
    String line = Console.ReadLine(); // enter the copied path. 
    string u202 = "\u202A";
    if(line.Contains(u202))
        Console.WriteLine("matched.");
