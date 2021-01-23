    class Program
    {
        List<string> data = new List<string>(){ "ABC", "DEF", "H" };
        static void Main(string[] args)
        {
            var p = new Program();
        }
        private Program()
        {
            UseWhereAndAny();
            UseAny();
        }
        private void UseWhereAndAny()
        {
            var moreThan2 = data.Where(m => m.Length > 2).Any();
        }
        private void UseAny()
        {
            var moreThan2 = data.Any(m => m.Length > 2);
        }
    }
