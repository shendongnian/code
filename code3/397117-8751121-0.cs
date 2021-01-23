    public class CustomComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            string o1 = x as string;
            string o2 = y as string;
            string[] parts1 = o1.Split('.');
            string[] parts2 = o2.Split('.');
            // Assuming first part is alpha, last part is numeric
            if (parts2.Length < 2 || parts2.Length < 2)
                return o1.CompareTo(o2);
            if (parts1[0].Equals(parts2[0]))
            {
                // Do a numeric compare
                return int.Parse(parts1[parts1.Length - 1]).CompareTo(int.Parse(parts2[parts2.Length - 1]));
            }
            else
            {
                // Just compare the first part
                return parts1[0].CompareTo(parts2[0]);
            }
        }
