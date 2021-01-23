    public List<string> CheckConditions(params List<string>[] conditions)
    {
         IEnumerable<string> result = myList;
         foreach (var condition in conditions)
         {
               result = result.Intersect(condition);
         }
    
         return result.ToList();
    }
