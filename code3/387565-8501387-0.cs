    public static T GetFromState<T>(string key) {
        byte[] blob = {standard state provider get by key}
        using(var ms = new MemoryStream(blob)) {
            return Serializer.Deserialize<T>(ms);
        }
    }
