            Dictionary<String, String> dict = new Dictionary<string, string>();
            for (int i = 0; i < 100; i++) {
                dict.Add("" + i, "" + i);
            }
            long start = DateTime.Now.Ticks;
            String s = dict["10"];
            Console.WriteLine(DateTime.Now.Ticks - start);
            for (int i = 100; i < 100000; i++) {
                dict.Add("" + i, "" + i);
            }
            start = DateTime.Now.Ticks;
            s = dict["10000"];
            Console.WriteLine(DateTime.Now.Ticks - start);
