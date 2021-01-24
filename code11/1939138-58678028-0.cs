    class Program
    {
        static void Main(string[] args)
        {
            var t = new Test(new int[] { 1, 2, 3, 4 });
            var value = t["valueOne"][0];
            Console.WriteLine(value);
        }
    }
    public class Test
    {
        private Dictionary<string, int[]> _data = new Dictionary<string, int[]>();
        public Test(int[] data)
        {
            _data.Add("valueOne", new int[] { data[0], data[1]});
            _data.Add("valueTwo", new int[] { data[2], data[3]});
        }
        public int[] this [string value]
        {
            get { return _data[value]; }
        }
      
    }
