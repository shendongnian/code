    public static string Past(this string s, string starter) {
        var starterPos = s.IndexOf(starter);
        return starterPos == -1 ? String.Empty : s.Substring(starterPos + starter.Length);
    }
    public static string UpTo(this string s, string stopper) {
        var stopPos = s.IndexOf(stopper);
        return (stopPos >= 0) ? s.Substring(0, stopPos) : s;
    }
