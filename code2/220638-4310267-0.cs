    class Program
    {
        private int index = 0;
        private static void Main()
        {
            new Program().TryMe();
        }
        
        private void TryMe()
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            list[index++] = ReturnZero();
        }
        private int ReturnZero()
        {
            Console.WriteLine(string.Format("index = {0}", index));
            return 0;
        }
    }
