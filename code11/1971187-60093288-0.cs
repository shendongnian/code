    var arr = [ 0.4, 20.33, 76.01, 47.3, 23.78];
    //or
    var arr = [ 32, 68, 89, 27, 93];
    // or 
    var arr = [ "Football", "Rugby", "Cricket", "Tennis", "Basketball"];
    
    
    var count = 2;
    var item = new JArray();
    
    foreach (var m in Enumerable.Range(0, count).Select(i => arr[GlobalFun.RandomInt(arr.Count())]))
    {
      if (!item.Contains(m))
      {
         item.Add(m);
      }
    }
    
    public static class GlobalFun
    {
        static Random random = null;
        private static readonly object syncLock = new object();
    
        static GlobalFun()
        {
            lock (syncLock)
            {
                if (random == null)
                    random = new Random();
            }
        }   
    
        public static int RandomInt(int max)
        {
            lock (syncLock)
            {
                return random.Next(max);
            }
        } 
    }
