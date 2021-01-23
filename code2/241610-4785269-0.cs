    class IPComparer : IComparer<string> {
        public int Compare(string a, string b) {
            return Enumerable.Zip(a.Split('.'), b.Split('.'), 
                                 (x, y) => int.Parse(x).CompareTo(int.Parse(y)))
                             .FirstOrDefault(i => i != 0); 
        }
    }
