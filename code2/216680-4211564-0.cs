    public class MyType
    {
        private List<string> items;
        public List<string> Items { get {
            return items ?? (items = new List<string>()); } }
    }
