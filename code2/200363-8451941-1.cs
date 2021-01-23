    string testString = "http://test# space 123/text?var=val&another=two";
    Console.WriteLine("UrlEncode:         " + System.Web.HttpUtility.UrlEncode(testString));
    Console.WriteLine("EscapeUriString:   " + Uri.EscapeUriString(testString));
    Console.WriteLine("EscapeDataString:  " + Uri.EscapeDataString(testString));
    Console.WriteLine("EscapeDataReplace: " + Uri.EscapeDataString(testString).Replace("%20", "+"));
    
    Console.WriteLine("HtmlEncode:        " + System.Web.HttpUtility.HtmlEncode(testString));
    Console.WriteLine("UrlPathEncode:     " + System.Web.HttpUtility.UrlPathEncode(testString));
