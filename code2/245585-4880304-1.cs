    interface IHasId
    {
       public int Id { get; }
    }
    
    public static IList<int> GetIds<T>(IList<T> items) where T:IHasId
    {            
        return items.Select(item => item.Id).ToList();
    }
