    public string GetResources(int languageCode, string key)
    {
        var serializer = new DataContractJsonSerializer(typeof(Dictionary<string, string>));
        using (var stream = this.GetType().Assembly.GetManifestResourceStream($"Namespace.{languageCode}.json"))
        {
            if (stream != null)
            {
                var map = (Dictionary<string, string>)serializer.ReadObject(stream );
                string value;
                if (map.TryGetValue(key, out value)) 
                {
                   return value;
                }
            }
        }
        return result;
    }
