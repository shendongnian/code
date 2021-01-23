    byte[] raw;
    using(var client = new WebClient()) { // in System.Net
        raw = client.DownloadData(url);
    }
    var binary = new Binary(raw); // in System.Data.Linq
