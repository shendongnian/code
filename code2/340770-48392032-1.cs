    using System.Net;
    using mshtml;
    using (var client = new WebClient())
    {
        var s = client.DownloadString(@"https://stackoverflow.com/questions/7264659/read-text-from-web-page");
        var htmldoc2 = (IHTMLDocument2)new HTMLDocument();
        htmldoc2.write(s);
        var plainText = htmldoc2.body.outerText;
        Console.WriteLine(plainText);
    }
