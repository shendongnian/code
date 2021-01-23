    class GeoIp
    {
        static public GeoIpData GetMy()
        {
            string url = "http://freegeoip.net/xml/";
            WebClient wc = new WebClient();
            wc.Proxy = null;
            MemoryStream ms = new MemoryStream(wc.DownloadData(url));
            XmlTextReader rdr = new XmlTextReader(url);
            XmlDocument doc = new XmlDocument();
            ms.Position = 0;
            doc.Load(ms);
            ms.Dispose();
            GeoIpData retval = new GeoIpData();
            foreach (XmlElement el in doc.ChildNodes[1].ChildNodes)
            {
                retval.KeyValue.Add(el.Name, el.InnerText);
            }
            return retval;
        }
    }
