    using (StreamReader reader = new StreamReader("infile.txt"))
    {
        using (StreamWriter writer = new StreamWriter("outfile.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                int index = line.LastIndexOf(' ');
                if (index > 0 && index + 1 < line.Length)
                {
                    writer.WriteLine(line.Substring(index + 1));
                }
            }
        }
    }
