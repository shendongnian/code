    static class MemoryLeak
    {
        static List<Action<int>> list = new List<Action<int>>();
        public static event Action<int> ActivateLeak
        {
            add
            {
                list.Add(value);
            }
            remove
            {
                list.Remove(value);
            }
        }
    }
   
