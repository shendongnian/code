    string input = "<p>Hello,&nbsp;World<br>Foo<br>Bar</p>";
    string[] replaceItems = { "<p>", "&nbsp;", "<br>" };
    if (replaceItems.Length > 0)
    {
        string pattern =
            String.Join("|", replaceItems.Select(s => Regex.Escape(s)).ToArray());
        string result = Regex.Replace(input, pattern, String.Empty);
        Console.WriteLine(result);
    }
    else
    {
        // nothing to replace
        Console.WriteLine(input);
    }
