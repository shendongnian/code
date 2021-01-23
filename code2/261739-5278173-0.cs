    public List<string> CheckConditions(params Func<X, List<string>>[] conditions)
    {
         IEnumerable<string> result = myList;
         foreach (var condition in conditions)
         {
               result = result.Intersect(condition(this));
         }
         
         return result.ToList();
    }
