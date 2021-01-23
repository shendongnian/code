    string path = @"path\to\your\file.ext";
    using (StreamReader sr = new StreamReader(path, true))
    {
        while (sr.Peek() >= 0)
        {
            Console.Write((char)sr.Read());
        }
        //Test for the encoding after reading, or at least
        //after the first read.
        Console.WriteLine("The encoding used was {0}.", sr.CurrentEncoding);
        Console.ReadLine();
        Console.WriteLine();
    }
