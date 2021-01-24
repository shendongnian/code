        private static void Main(string[] args)
        {
            Test(("a", (1, "b")));
            TestWrap(
                ("a", (1, "b")), 
                ("b", (3, "c"))
                );
        }
        private static void Test((string, (int, string)) data)
        {
        }
        private static void TestWrap(params (string, (int, string))[] data)
        {
            Test2(data.ToDictionary(v => v.Item1, v => v.Item2));
        }
        private static void Test2(Dictionary<string, (int, string)> data)
        {
        }
