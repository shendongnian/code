    Console.WriteLine("Enter a string");
    string input = Console.ReadLine();
    string s = "";
    for (int i = input.Length-1 ; i >= 0; i--)
    {
        s = s + input[i];
    }
    Console.WriteLine(s);
