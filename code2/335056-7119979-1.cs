    public string Base64Decode(string data)
    {
        byte[] byteArray = Convert.FromBase64String(data);
        var message = System.Text.Encoding.UTF8.GetString(byteArray);
        return message;
    }
