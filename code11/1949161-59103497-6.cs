    using (StreamReader r = new StreamReader(filepath))
    {
         string json = r.ReadToEnd();
         var obj = JsonConvert.DeserializeObject<List<item>>(json);
         Dictionary<string, bool> keyValuePairs = new Dictionary<string, bool>();
         foreach (var keyvalue in obj)
         {
              if (!keyValuePairs.ContainsKey(keyvalue.foo))
                 keyValuePairs.Add(keyvalue.foo, keyvalue.bar);
         }
    }
