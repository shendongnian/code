    public static IEnumerable<char> AllChars;
    public static IEnumerable<char> Expanded;
    static <ClassName> {
        AllChars = Enumerable.Range(0, 256).Select(Convert.ToChar).Where(c => !char.IsControl(c));
        Expanded = ExpandCharacterSet(...);
    }
