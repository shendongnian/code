    public static void Serialize<T>(this IList<T> list, string fileName)  
    {
       try
       {
          var ds = new DataContractSerializer(list.GetType());
          using (Stream s = File.Create(fileName))
            ds.WriteObject(s, list);  
       }
       catch (Exception e)
       {
         _logger.Error(e);
         throw;
       } 
    } 
