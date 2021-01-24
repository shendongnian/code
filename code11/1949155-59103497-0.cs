    using (StreamReader r = new StreamReader(filepath))
    {
         string json = r.ReadToEnd();
         var obj = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
         Dictionary<string, bool> keyValuePairs = new Dictionary<string, bool>();
         foreach (var keyvalue in obj)
         {
              keyValuePairs.Add(keyvalue["foo"].ToString(), Convert.ToBoolean(keyvalue["bar"]));
         }
    }
