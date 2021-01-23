    static void Main(string[] args)
    {
        string input = "ABCDEFGHIJ";
        string output = input.Overwrite(3, "ZX"); // 4th position has index 3
        // ABCZXFGHIJ
    }
    public static string Overwrite(this string text, int position, string new_text)
    {
        return text.Substring(0, position) + new_text + text.Substring(position + new_text.Length);
    }
