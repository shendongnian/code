    var s = "Put your  repair hobby on your résumé."; 
    //  takes two UTF-16 code units. 
    // Second é is two codepoints: "e\u0301", base and combining codepoints
    
    var e = StringInfo.GetTextElementEnumerator(s);
    while (e.MoveNext())
    {
        var grapheme = (String)e.Current;
        Console.WriteLine(grapheme);
       
        foreach (var codepoint in grapheme.AsCodePointEnumerable())
        {
            var info = UnicodeInfo.GetCharInfo(codepoint);
            Console.WriteLine($"    U+{codepoint:X04} {info.Name} {info.Category}");
        }
    }
