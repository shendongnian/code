    string lines;
    lines = File.ReadAllText(path);
    Console.WriteLine(lines);
    //Add line to original document
    File.AppendAllLines(@path, new string[] { "" + "This line is added 
    by Visual Studio" });
    //Read new lines
    lines = File.ReadAllText(path);
    
    Console.WriteLine(lines);
