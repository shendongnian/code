    var vendors = new Dictionary<string, string>();
    using (var reader = new StreamReader(@"c:\temp\test.txt"))
    {
        string line = string.Empty;
        while ((line = reader.ReadLine()) != null)
        {
            string[] keyValue = line.Split(new char[] { '=' });
            vendors.Add(keyValue[0], keyValue[1]);
        }
    }
