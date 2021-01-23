    public static IEnumerable<Tuple<double, double>> ReadCSV(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var split = line.Split(new[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries);
    
                yield return new Tuple<double, double>(
                    double.Parse(split[0], CultureInfo.InvariantCulture),
                    double.Parse(split[1], CultureInfo.InvariantCulture));
            }
        }
    }
