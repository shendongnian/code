    class Program
    {
        private static Dictionary<int, Type> TypeMapping { get; set; }
        static void Main(string[] args)
        {
            TypeMapping = new Dictionary<int, Type>();
            Test test1 = Test.Test1;
            TypeMapping.Add((int)test1, test1.GetType());
        }
    }
    public enum Test
    {
        Test1 = 1,
        Test2 = 2
    }
