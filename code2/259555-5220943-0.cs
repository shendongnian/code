     string NewJobString = null;
        Job JobDetails = (Job)Table;
        var prpsJob = typeof(Job).GetProperties(b);
        foreach (var p in prpsJob)
        {
               object x = p.GetGetMethod().Invoke(Table, null);
               x = StripDate(x);
               NewJobString += p.Name + ": " + x + Environment.NewLine;
        }
    
    public string GetProperties(Type t, BindingFlags b)
    {
         StringBuilder sb = new StringBuilder();
         var prpsJob = typeof(t).GetProperties(b);
         foreach (var p in prpsJob)
         {
              object x = p.GetMethod().Invoke(Table, null);
              x = StripDate(x);
              sb.Append(p.Name + ": " + x + Environment.NewLine);
         }
         return sb.ToString()
    }
