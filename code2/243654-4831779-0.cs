    using (StreamReader r = new StreamReader("newfile.txt"))
    {
        while (r.Peek() >= 0)
        {
            string line = r.ReadLine();
            var dictionary = new Dictionary<String, Int32>();
            var records = line.Split(',');
            // use records....  Note that above is the same as:
            // string[] records = line.Split(',');
        }
    }
