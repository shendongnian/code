    public static String HighlightTwitter(String input)
    {
        String result = Regex.Replace(input, @"\b\@\w+", @"<font color=""red"">$0</font>");
        result = Regex.Replace(result, @"\b#\w+", @"<font color=""blue"">$0</font");
        result = Regex.Replace(result, @"\bhttps?://[-\w]+(\.\w[-\w]*)+(:\d+)?(/[^.!,?;""\'<>()\[\]\{\}\s\x7F-\xFF]*([.!,?]+[^.!,?;""\'<>\(\)\[\]\{\}\s\x7F-\xFF]+)*)?\b", @"<font color=""yellow"">$0</font", RegexOptions.IgnoreCase);
        return result;
    }
