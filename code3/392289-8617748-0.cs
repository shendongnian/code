    var lines = File.ReadAllLines(args[0])
    string name = lines[4];
    if (lines.Length != 6) // Check if EOF is 0 or not.
        lines.Add("1");
    else
        lines[5] = "1";
    File.WriteAllLines(args[0], lines);
    Console.WriteLine(name);
