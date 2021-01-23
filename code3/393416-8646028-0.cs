    for (int i = 0; i < messages.Length; i++)
    {
        Console.WriteLine("I'm eating a " + messages[i]); // reading the value
        messages[i] = "blabla" + i.ToString(); // writing a value to the array
    }
