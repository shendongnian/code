    WebClient wc = new WebClient();
    byte[] data = wc.DownloadData(
        "http://www.datasource.com/apps/qt/csv/pricehistory.ac?section=yearly_price_download&code=XXX");
    using (var ms = new MemoryStream(data))
    {
        using (var reader = new StreamReader(ms))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // do whatever
            }
        }
    }
