    while (true)
    {
        Console.Write("Path: ");
        string path = Console.ReadLine();
        Console.Write("Text to search: ");
        string search = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(path) || string.IsNullOrWhiteSpace(search))
        {
            break;
        }
        if (!File.Exists(path))
        {
            Console.WriteLine("File doesn't exists!");
            continue;
        }
        int index = File.ReadAllText(path).IndexOf(search);
        string output = String.Format("Searched Text Position: {0}", index == -1 ? "Not found!" : index.ToString());
        File.WriteAllText("output.txt", output);
        
        Console.WriteLine("Finished! Press enter to continue...");
        Console.ReadLine();
        Console.Clear();
    }
