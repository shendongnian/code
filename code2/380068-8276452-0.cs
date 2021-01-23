    void Main()
    {
 
        WebClient webClient = new WebClient();
	
	
	
        byte[] b = webClient.DownloadData("http://www.mcxindia.com/sitepages/BhavCopyDateWise.aspx");
	
        string s = System.Text.Encoding.UTF8.GetString(b);
	
        var __EVENTVALIDATION = ExtractVariable(s, "__EVENTVALIDATION");
	
        __EVENTVALIDATION.Dump();
	
        var forms = new NameValueCollection(); 
	
        forms["__EVENTTARGET"] = "btnLink_Excel";
        forms["__EVENTARGUMENT"] = "";
        forms["__VIEWSTATE"] = ExtractVariable(s, "__VIEWSTATE");
        forms["mTbdate"] = "11%2F15%2F2011";
        forms["__EVENTVALIDATION"] = __EVENTVALIDATION;
	
        webClient.Headers.Set(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
	
        var responseData = webClient.UploadValues(@"http://www.mcxindia.com/sitepages/BhavCopyDateWise.aspx", "POST", forms); 
        System.IO.File.WriteAllBytes(@"c:\11152011.csv", responseData);
    }
    private static string ExtractVariable(string s, string valueName)
    {
         string tokenStart = valueName + "\" value=\"";
         string tokenEnd = "\" />";
         int start = s.IndexOf(tokenStart) + tokenStart.Length;
         int length = s.IndexOf(tokenEnd, start) - start;
         return s.Substring(start, length);
    }
