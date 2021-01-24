        private static void TotalsByLength()
        {
            List<Tuple<string, int>> tagdata = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("abs", 8),
                new Tuple<string, int>("cde", 8),
                new Tuple<string, int>("fgh", 10)
            };
            var tagcounts = from p in tagdata
                group p.Item2 by p.Item2 into g
                orderby g.Count() descending
                select new { g.Key, TotalOccurrence = g.Count() };
            foreach (var s in tagcounts)
            {
                Console.WriteLine("{0}/{1}", s.TotalOccurrence, s.Key );
            }
        }
