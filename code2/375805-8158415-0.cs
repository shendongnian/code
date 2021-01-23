    public static string outputDictionaryContents(Dictionary<string, int> list) 
    {
         StringBuilder returnValue = new StringBuilder(); 
         foreach (KeyValuePair<string, int> pair in list) 
         { 
              returnValue.AppendFormat("{0}, {1}", new object[] { pair.Key, pair.Value }); 
         } 
         return returnValue.ToString();
    } 
