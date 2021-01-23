    public static T FromBase64<T>(this string base64Text)
    {
        byte[] bytes = Convert.FromBase64String(base64Text);
        string json = Encoding.Default.GetString(bytes);
        return JsonConvert.DeserializeObject<T>(json);
    }
