    private static void WriteValues(List<Value> fileContent)
    {
        var dateGroups = fileContent
            .GroupBy(v => $"ordinivoa_999999.{v.date:yyMMddHHmmssfff}");
        foreach (var group in dateGroups) {
            string path = Path.Combine(toLinfaFolder, group.Key);
            using (var writer = new StreamWriter(path, true, Encoding.ASCII)) {
                foreach (Value item in group) {
                    //TODO: write item to file
                    writer.WriteLine(...
                }
            }
        }
    }
