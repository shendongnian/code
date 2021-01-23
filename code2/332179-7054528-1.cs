    Console.Write("Working on file " + images[x] + " please wait\r");
    if (!File.Exists(images[x]))
    {
        Console.Write("The file " + images[x] + " is not exist\r");
        sw.WriteLine("The file " + images[x] + " is not exist");
    } else {
        for (y = x + 1; y < images.Length; y++)
        {
           // Etc
        }
    }
