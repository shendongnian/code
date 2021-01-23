    static string stripHTMLTags(string str)
    {
        var expression = new Regex("<[^>]+>");
        return expression.Replace(str, "");
    }
    static void Main(string[] args)
    {
        string a = "<td width=10></td><td>Strip html</td>";
        // Outputs -> Strip html
        Console.WriteLine(stripHTMLTags(a));
    }
