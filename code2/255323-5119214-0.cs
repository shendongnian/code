            HttpWebRequest w = (HttpWebRequest)HttpWebRequest.Create("http://stackoverflow.com/favicon.ico");
            w.AllowAutoRedirect = true;
            HttpWebResponse r = (HttpWebResponse)w.GetResponse();
            System.Drawing.Image ico;
            using (Stream s = r.GetResponseStream())
            {
                ico = System.Drawing.Image.FromStream(s);
            }
            ico.Save("favicon.ico");
