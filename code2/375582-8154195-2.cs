    public static string[] Sort(this string[] list, string start)
    {
        List<string> l = new List<string>();
        l.AddRange(list.Where(p => p.StartsWith(start)).OrderBy(p => p));
        l.AddRange(list.Where(p => !p.StartsWith(start)));
        // l.AddRange(list.Where(p => !p.StartsWith(start)).OrderByDescending(p => p));
        return l.ToArray();
    }
