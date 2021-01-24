    string oldStr = "&amp;nbsp; &amp;nbsp; &amp;nbsp; &amp;nbsp;";
    
    var result = HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(oldStr));
    
    Console.WriteLine(string.IsNullOrWhiteSpace(result)); 
