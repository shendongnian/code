            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(URI);
            //Add these, as we're doing a POST
            req.KeepAlive = false;
            req.Method = "POST";
            req.Headers.Add("GData-Version", "2.0");
            req.Headers.Add("Slug", "A new map");
            req.Headers.Add("Authorization", "GoogleLogin auth=" + auth);
            FileStream fs = new FileStream("E:\\Surajit\\MapPoint\\1.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            req.ContentLength = fs.Length;
            req.ContentType = "text/csv";
            Stream outputStream = req.GetRequestStream();
            WriteInputStreamToRequest(fs, outputStream);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            outputStream.Close();
            fs.Close();
            if (resp == null) return null;
            StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
