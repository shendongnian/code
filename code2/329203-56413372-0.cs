    public static string ToBase64(this object obj)
    {
        string json = JsonConvert.SerializeObject(obj);
        byte[] bytes = Encoding.Default.GetBytes(json);
        return Convert.ToBase64String(bytes);
    }
