            List<OBJ> Test = new List<OBJ>();
            Test.Add(new OBJ(1));
            Test.Add(new OBJ(2));
            string Order = "1,2,3";
            List<string> OrderBy = Order.Split(new char[] { ',' }).ToList();
            Test = Test.OrderBy(x => OrderBy.IndexOf(x.Field1.ToString())).ToList();
            Console.ReadKey();
