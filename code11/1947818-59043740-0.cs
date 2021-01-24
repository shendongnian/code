    private static List<ValueDTO> LoadItems(Stream stream)
    {
        var result = new List<ValueDTO>();
        using (var reader = new StreamReader(stream))
        {
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    result.Add(JsonConvert.DeserializeObject<ValueDTO>(line));
                }
            }
        }
        return result;
    }
