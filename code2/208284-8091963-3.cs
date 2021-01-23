    using System.Net;
    ...
    using (var wb = new WebClient())
    {
        var response = wb.DownloadString(url);
    }
