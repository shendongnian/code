    using (var reader = new StreamReader("input.txt", Encoding.GetEncoding("Windows-1251")))
    using (var writer = new StreamWriter("output.txt", false, Encoding.UTF8))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            // reading the input file line by line ...
            // perform the parsing and write to the UTF-8 output encoded file
            writer.WriteLine(line);
        }
    }
