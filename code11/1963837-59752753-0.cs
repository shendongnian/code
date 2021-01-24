    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            dictionary.Add("Test1", new List<string>() { "Test1", "Test2", "Test3" });
            dictionary.Add("Test2", new List<string>() { "Test2", "Test3", "Test1" });
            dictionary.Add("Test3", new List<string>() { "Test3", "Test2", "Test1" });
            dictionary.RemoveStringFromEveryList("Test1");
        }
    }
    public static class Extensions
    {
        public static void RemoveStringFromEveryList(this Dictionary<string, List<string>> dictionary, string wordToRemove)
        {
            foreach(var keyValue in dictionary)
            {
                keyValue.Value.RemoveAll(x => x == wordToRemove);
            }
        }
    }
