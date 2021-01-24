      SavePattern savePatt = new SavePattern();
      PropertyInfo[] properties = typeof(SavePattern).GetProperties();
      foreach (PropertyInfo property in properties)
       {
         var val = property.GetValue(savePatt);
       }   
