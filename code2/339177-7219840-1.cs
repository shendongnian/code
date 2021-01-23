            Dictionary<int, string> _tags = new Dictionary<int, string>();
            for (int i = 0; i < 1000000; i++)
            {
                _tags.Add(i, i.ToString().Length + "");
            }
            string text = new String('a' , 50000000);
            Console.WriteLine("****************************************");
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            StringBuilder sb = new StringBuilder(text);
            foreach (KeyValuePair<int, string> pair in _tags)
            {
                sb.Insert(pair.Key, pair.Value);
            }
            sw.Stop();
            Console.WriteLine("sw:" + sw.ElapsedMilliseconds);
            Console.ReadKey();
