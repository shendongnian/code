    static void Main(string[] args)
    {
      string sUrl1 = "http://localhost:22666/HtmlEdit.aspx?mid=0&page=123&test=12";
      string sUrl2 = "http://localhost:22666/HtmlEdit.aspx?mid=0&page=125612";
      string sUrl3 = "http://localhost:22666/HtmlEdit.aspx?mid=0&pager=12";
      string sUrl4 = "http://localhost:22666/HtmlEdit.aspx?page=12&mid=0";
    
      string sRc = string.Empty;
      sRc = ChangePage(sUrl1);
      Console.WriteLine(sRc);
      sRc = ChangePage(sUrl2);
      Console.WriteLine(sRc);
      sRc = ChangePage(sUrl3);
      Console.WriteLine(sRc);
      sRc = ChangePage(sUrl4);
      Console.WriteLine(sRc);
    }
