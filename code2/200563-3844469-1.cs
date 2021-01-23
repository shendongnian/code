    public class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        }
    }
    IList<MyObject> myobj = new List<MyObject>();
    var orderedList = myobj.OrderBy(x => x.marker, new CaseInsensitiveComparer()).ToList();
