        private static void KeepOnlyOneFor(List<Pic> intTime, Func<Pic, int> Grouping, DateTime ApplyBefore)
        {
            var groups = intTime.Where(a => a.when < ApplyBefore).OrderBy(a=>a.when).GroupBy(Grouping);
           foreach (var r in groups)
           {
               var s = r.Where(a=> a != r.LastOrDefault());
               intTime.RemoveAll(a => s.Contains(a));
           }
        }
