    public static string Serialize(IEnumerable items)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in items)
        {
            sb.AppendLine(JsonConvert.SerializeObject(item));
        }
        return sb.ToString();
    }
