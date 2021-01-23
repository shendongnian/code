        [TestMethod]
        public void TestDictionary()
        {
            Dictionary<String, Int32> d1 = new Dictionary<string, int>();
            Dictionary<String, Int32> d2 = new Dictionary<string, int>();
            d1.Add("555", 1);
            d1.Add("abc2", 2);
            d1.Add("abc3", 3);
            d1.Remove("abc2");
            d1.Add("abc2", 2);
            d1.Add("556", 1);
            d2.Add("555", 1);
            d2.Add("556", 1);
            d2.Add("abc2", 2);
            d2.Add("abc3", 3);
            foreach (var i in d1)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            foreach (var i in d2)
            {
                Console.WriteLine(i);
            }
        }
