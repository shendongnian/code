    private void SomeMethod<T>(IEnumerable<Inventory> source, Func<Inventory,T> getProp)
    {
       var sb = new StringBuilder();
       foreach(var item in source) 
       {
          sb.AppendFormat("{0},{1}…", item.Name, getProp(item));
       }
    
       File.WriteAllText(filename, sb.ToString());    
    }
