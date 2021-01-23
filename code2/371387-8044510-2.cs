        static List<string> MyCollection = new List<string>()
            {
                "hello",
                "hello"
            };
        static bool ExistsUnique(Func<string, bool> p)
        {
            var tempCol = from i in MyCollection where p(i) select i;
            return tempCol.Count() == 1;
        }
        static void DoIt()
        {
            bool isUnique = ExistsUnique((s) => s.Equals("hello"));
            Console.WriteLine(isUnique);
        }
