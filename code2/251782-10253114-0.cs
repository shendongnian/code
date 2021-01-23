    var url = string.Format("https://www.google.com/accounts/ClientLogin?service=reader&Email={0}&Passwd={1}",
        HttpUtility.UrlEncode(email),
        HttpUtility.UrlEncode(password)
    );
    var web = new WebClient();
    web.DownloadStringCompleted += (sender, e) =>
    {
        var sid = e.Result.Split('\n')
            .First(s => s.StartsWith("SID="))
            .Substring(4);
    };
    web.DownloadStringAsync(new Uri(url));
