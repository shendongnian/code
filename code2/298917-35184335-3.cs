     public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
    {
            var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            });
            using (var writer = new StreamWriter(filePath, append))
            {
                writer.Write(contentsToWriteToFile);
            }
    }
