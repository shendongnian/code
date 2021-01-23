    public static List<T> ListCompare<T>(List<T> List1 , List<T> List2 , string key )
    {
        return List1.Select(t => t.GetType().GetProperty(key).GetValue(t)).Intersect(List2.Select(t => t.GetType().GetProperty(key).GetValue(t))).ToList();
        
      
    }
