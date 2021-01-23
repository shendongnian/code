    public string Convert(object value)
    {
        var data = value as IEnumerable;
        if (data == null)
          return "This is not a list ..."; // I think you missed this one
    
        var e = data.Cast<object>();
        return e.Count() == 0 ? 
                "" : 
                e.Select(o=>Convert(o)).Aggregate("", (c, s) => c+s);
        
    }
