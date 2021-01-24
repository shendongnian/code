 public static int Compare(string a, string b)
        {
            return int.Parse(a.Substring(0, 15)).CompareTo(int.Parse(b.Substring(0, 15)));
        }
and then invoke it in sort method:
stringList.Sort(Compare);
The prerequisite is that your format is satisfied that its first 15 characters can convert to an integer.
