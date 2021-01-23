    using (StreamReader sr = new StreamReader("C:\\Work\\list.txt"));
    {
        string contents = sr.ReadToEnd();
        if (contents.Contains(args[0]))
        {
            // ...
        }
    }
