    static void Main(string[] args)
    {
        var surl = "http://www.google.com?q=%2D";
        var url = new Uri(surl);
        Console.WriteLine("Broken: " + url.ToString());
        // Declared in Uri class as
        //     private UriInfo     m_Info;
        // https://referencesource.microsoft.com/#System/net/System/URI.cs,129
        FieldInfo infoField = url.GetType().GetField("m_Info", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        // Immediately after m_Info is declared, the private class definition is given:
        //     private class UriInfo {
        //         public string   String;
        //         ...
        //     };
        object info = infoField.GetValue(url);
        FieldInfo infoStringField = info.GetType().GetField("String");
        // If you check the value of m_Info.String, you'll see it has the
        // modified string with '?q=-'.
        // The idea with this block of code is to replace the parsed
        // string with the one that you want.
        // This just replaces the string with the original value.
        infoStringField.SetValue(info, surl);
		// ToString() @ https://referencesource.microsoft.com/#System/net/System/URI.cs,1661
		// There are a couple of 'if' branches, but the last line is
		//     return m_Info.String;
		// This is the idea behind the above code.
        Console.WriteLine("Fixed: " + url.ToString());
        // However, GetComponents uses entirely different logic:
        Console.WriteLine($"Still broken: {url.GetComponents(UriComponents.AbsoluteUri, UriFormat.Unescaped)}");
        Console.WriteLine($"Still broken: {url.GetComponents(UriComponents.AbsoluteUri, UriFormat.SafeUnescaped)}");
        Console.WriteLine($"Still broken: {url.GetComponents(UriComponents.AbsoluteUri, UriFormat.UriEscaped)}");
        Console.WriteLine("Press ENTER to exit ...");
        Console.ReadLine();
    }
