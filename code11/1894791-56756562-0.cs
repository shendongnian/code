    class Program
    {
        static void Main(string[] args)
        {
            List<Test> tests = new List<Test>() //Example objects
            {
                new Test
                {
                    A = 1,
                    B = 2,
                    C = 3,
                },
                new Test
                {
                    A = 2,
                    B = 2,
                    C = 3,
                },
                new Test
                {
                    A = 3,
                    B = 2,
                    C = 3,
                },
                new Test
                {
                    A = 1,
                    B = 1,
                    C = 3,
                },
                new Test
                {
                    A = 1,
                    B = 2,
                    C = 3,
                },
                new Test
                {
                    A = 1,
                    B = 3,
                    C = 3,
                },
                new Test
                {
                    A = 1,
                    B = 2,
                    C = 1,
                },
                new Test
                {
                    A = 1,
                    B = 2,
                    C = 2,
                },
                new Test
                {
                    A = 1,
                    B = 2,
                    C = 3,
                }
            };
            List<Test> results = DistinctBy(tests, "A"); //Use of DistinctBy
        }
        private static List<T> DistinctBy<T>(List<T> objs, string propertyName)
        {
            Type type = typeof(T);
            PropertyInfo property = type.GetProperty(propertyName);
            return objs.GroupBy(x => property.GetValue(x)).Select(x => x.First()).ToList();
        }
    }
    public class Test
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
    }
