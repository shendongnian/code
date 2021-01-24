    private static IEnumerable<Fruit> BuildFruitList(string csvFilePath)
    {
        if (!File.Exists(csvFilePath))
        {
            throw new FileNotFoundException("Could not locate CSV at path " + csvFilePath, csvFilePath);
        }
        try
        {
            using var fileReader = File.OpenText(csvFilePath);
            using var csv = new CsvReader(fileReader);
            return csv.GetRecords<Fruit>().ToList();
        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Enumerable.Empty<Fruit>();
        }
    }
    private static IEnumerable<FruitReferencePrice> BuildFruitReferenceList(string csvFilePath)
    {
        if (!File.Exists(csvFilePath))
        {
            throw new FileNotFoundException("Could not locate CSV at path " + csvFilePath, csvFilePath);
        }
        try
        {
            using var fileReader = File.OpenText(csvFilePath);
            using var csv = new CsvReader(fileReader);
            return csv.GetRecords<FruitReferencePrice>().ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Enumerable.Empty<FruitReferencePrice>();
        }
    }
