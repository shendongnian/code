        private static void TestOrderList()
        {
            var list = new List<string>();
            list.Add("MOUNTAIN GATE");
            list.Add("MOUNT ADA");
            list.Add("MOUNTAIN BAY");
            list.Add("MOUNT ALFRED");
            list.Add("MOUNTAIN VIEW");
            list.Add("MOUNT BEAUTY");
            var q = list.AsEnumerable().OrderBy(r => r.Replace(" ", ""));
            foreach(var s in q)
            {
                Console.WriteLine(s);
            }
        }
