    using (var client = new WebClient())
    using (var reader = new StreamReader(client.OpenRead(uri), Encoding.UTF8, true))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
