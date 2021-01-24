    private static List<Fruit> BuildFruitList(string path)
    {
        using var fileReader = File.OpenText(path);
        using var csv = new CsvReader(fileReader);
        return csv.GetRecords<Fruit>().ToList();
    }
    private static List<FruitReferencePrice> BuildFruitReferenceList(string path)
    {
        using var fileReader = File.OpenText(path);
        using var csv = new CsvReader(fileReader);
        return csv.GetRecords<FruitReferencePrice>().ToList();
    }
