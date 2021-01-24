        public static IEnumerable<string> Compare(List<string[]> items)
        {
            var liste = new List<string>() ;
            AddingElements(items, liste);
            return liste.Distinct();
        }
        private static void AddingElements(List<string[]> items, List<string> liste)
        {
            items.Skip(1).ToList().ForEach((e) =>
            {
                liste.AddRange(e.Difference(items.First()));
            });
        }
        public static string[] Difference(this string[] sourceArray, string[] stringArray)
        {
            return sourceArray.Where(e => stringArray.Contains(e))
                              .ToArray();
        }
