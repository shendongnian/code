    using (StreamReader reader = new StreamReader("path\\to\\file.csv"))
    {
        string line;
        while ((line = await reader.ReadLineAsync()) != null)
        {
         string[] values = line.Split(',');
         double.TryParse(values[pointsIndex], out double points);
        }
    }
