        public string Mediafire(string download)
		{
			HttpWebRequest req;
			HttpWebResponse res;
			string str = "";
			req = (HttpWebRequest)WebRequest.Create(download);
			res = (HttpWebResponse)req.GetResponse();
			str = new StreamReader(res.GetResponseStream()).ReadToEnd();
			int indexurl = str.IndexOf("http://download");
			int indexend = GetNextIndexOf('"', str, indexurl);
			string direct = str.Substring(indexurl, indexend - indexurl);
			return direct;
		}
