    var source = "А9"; // Cyrilic A9 - "\u0410\u0039"
    var map = new Dictionary<char,char> { { 'А', 'A' } }; // Cyrillic to Latin 
    var chars = source.Select( c =>
         CharUnicodeInfo.GetUnicodeCategory(c)==UnicodeCategory.DecimalDigitNumber?
               CharUnicodeInfo.GetDigitValue(c).ToString()[0] :
         map.ContainsKey(c) ? map[c] : 
         c);
    var result = String.Join("", chars);
    var term = "\u0041\u0039"; // Latin A9
    Console.WriteLine(source.Contains(term));       
    Console.WriteLine(result.Contains(term));
