            Dictionary<int, string> _tags = new Dictionary<int, string>();
            for (int i = 0; i < 1000000; i++)
            {
                _tags.Add(i, i.ToString().Length + "");
            }
            Console.WriteLine("****************************************");
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<int, string> pair in _tags)
            {
                sb.Insert(pair.Key, pair.Value);
            }
            sw.Stop();
            Console.WriteLine("sw:" + sw.ElapsedMilliseconds / 1000 + "s");
            Console.ReadKey();
