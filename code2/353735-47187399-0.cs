    public AjaxDictionary( SerializationInfo info, StreamingContext context )
    {
         _Dictionary = new Dictionary<TKey, TValue>();
         foreach (SerializationEntry kvp in info)
         {
             _Dictionary.Add((TKey)Convert.ChangeType(kvp.Name, typeof(TKey)), (TValue)Convert.ChangeType(kvp.Value, typeof(TValue)));
         }
    }
