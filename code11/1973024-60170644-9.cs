    public static class Helper1
    {
        public static async Task<List<string>> GetStuff()
        {
            return await Task.Run(() => new List<string>{"78", "98", "56",});
        }
    }
    public static class Helper2
    {
        public static async Task<List<int>> GetStuff()
        {
            return await Task.Run(() => new List<int>{1, 2, 3, 4, 5, 6});
        }
    }
