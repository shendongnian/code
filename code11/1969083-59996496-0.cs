        private static void TestSplitRegexLinq()
        {
            var list = new List<string>{"W848","W998, W748","W953, W9484, W7373","W888"};
            string pattern = @"[W][0-9]*";                
            var reg = new Regex(pattern);
            list.ForEach(p => reg.Matches(p).ToList().ForEach(d => Console.WriteLine(d.Value)));
        }
        private static void TestSplitRegexLoop()
        {
            var list = new List<string>{"W848","W998, W748","W953, W9484, W7373","W888"};
            string pattern = @"[W][0-9]*";                
            var reg = new Regex(pattern);
            foreach (var item in list)
            {
                foreach (Match item2 in reg.Matches(item))
                {
                    Console.WriteLine(item2.Value);
                }
            }
        }
