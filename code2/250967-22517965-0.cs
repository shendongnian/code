    ///Examples:
    ///    "this is my string".ReplaceAt(0, "Hello World") = "Hello Worldstring"
    ///    "OVERFLOW!".ReplaceAt(4, "WRITTEN!") = "OVERWRITTEN!"
    public static string ReplaceAt(this string str, int index, string replace)
    {
        return str.Remove(index, Math.Min(replace.Length, str.Length - index))
                .Insert(index, replace);
    }
