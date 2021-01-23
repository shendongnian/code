    void CopyAndEdit(string inputFile, string outputFile)
    {
        // In .NET 4 you can use File.ReadLines which will
        // return an IEnumerable<string>
        using (TextReader reader = File.OpenText(inputFile))
        {
            using (TextWriter writer = File.CreateText(outputFile))
            {
                bool editing = true;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(line);
                    if (editing && line.Contains("some text"))
                    {
                        editing = false;
                        writer.WriteLine("some text something else");
                    }
                }
            }
        }
    }
