          public static void DumpObject(this object value)    
          {
           Console.WriteLine(JsonConvert.SerializeObject(value, Formatting.Indented));  
 
          }
