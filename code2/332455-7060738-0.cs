    public class CustomComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            string s1 = (string) x;
            string s2 = (string) y;
            return DateTime.Compare(DateTime.ParseExact(s1.Substring(1), "MMddyyyy", CultureInfo.InvariantCulture), 
                                    DateTime.ParseExact(s2.Substring(1), "MMddyyyy", CultureInfo.InvariantCulture));
        }
    }
    ..
    ArrayList items = new ArrayList();
    items.Add("a08102011");
    items.Add("a09112011");
    items.Sort(new CustomComparer());
