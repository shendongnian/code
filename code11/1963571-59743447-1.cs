        private static void TestOrderList()
        {
            var list = new List<string>();
            list.Add("MOUNTAIN GATE");
            list.Add("MOUNT ADA");
            list.Add("MOUNTXADA");
            list.Add("MOUNTAIN BAY APP TOAST");
            list.Add("MOUNTAIN BAY APP ATOAST");
            list.Add("MOUNTAIN BAY APPA");
            list.Add("MOUNTAIN BAY");
            list.Add("MOUNT ALFRED");
            list.Add("MOUNTAIN VIEW");
            list.Add("MOUNT BEAUTY");
            var q = list.AsEnumerable().OrderBy(r => r.Replace("~", ""));
            q.ToList().ForEach(s => Console.WriteLine(s));
        }
