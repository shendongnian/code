    public static string ReplaceAt(this string str, int index, string replace)
    {
        return str.Remove(index, Math.Min(replace.Length, str.Length - index))
                .Insert(index, replace);
    }
