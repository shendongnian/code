    class DTO
    {
      public List<Dictionary<string, object>> collectionList { get; set; } //just a simple example
      
      public object Get(string key)
      {
        if(collectionList != null)
        {
           foreach(var c in collectionList) //iterate through each collection
           {
            /*If your collection list is a of type List<ICollection>, you have to find the type of c 
            using reflection and then use a switch-case to fetch the key appropriately
            depending on it's implementation. 
            For simplicity I'm assuming all the collection objects are dictionaries*/
             if(c.ContainsKey(key)) 
                return c[key];
           }
        }
        return null;
      }
    }
