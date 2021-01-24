        string path = Directory.GetCurrentDirectory();
    string[] files = Directory.GetFiles(path);
    Console.WriteLine("Enter the name of the file to copy");
    source = Console.ReadLine();
    Console.WriteLine("Enter a name for the new file:");
    string target = Console.ReadLine();
    File.Copy(source, target);
    Console.WriteLine("\n\nNew listing:");
    
    files = Directory.GetFiles(path); //this added
    
    foreach (var file in files)
           Console.WriteLine(file);
