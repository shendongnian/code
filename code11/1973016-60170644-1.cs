    public static class Helper1
    {
       public static async Task<List<X>> GetStuff()
       {
           List<X> items = ......;
           return await Task.FromResult(items);
       }
    }
        
    public static class Helper2
    {
       public static async Task<List<Y>> GetStuff()
       {
           List<Y> items = ......;
           return await Task.FromResult(items);
       }
    }
