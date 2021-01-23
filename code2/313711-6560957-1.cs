    static void Main(string[] args)
            {
                IDictionary<int,int> s = new Dictionary<int, int>();
                ObservableCollection<int> s1 = new ObservableCollection<int>();
                IList<int> s2 = new List<int>();
    
                int count = GetCount(s.ToList());
                int count1 = GetCount(s1.ToList());
                int count2 = GetCount(s2.ToList());
    
            }
     private static int GetCount(ICollection s)
            {
                return s.Count;
            }
