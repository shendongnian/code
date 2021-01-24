private void scrape_button_Click(object sender, EventArgs e) {
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.discogs.com/releases/2890373");
			httpWebRequest.Method = WebRequestMethods.Http.Get;
			httpWebRequest.Accept = "application/vnd.discogs.v2.html+json";
			httpWebRequest.UserAgent = "matija_search/1";
			string file;
			var response = (HttpWebResponse)httpWebRequest.GetResponse();
			using(var sr = new StreamReader(response.GetResponseStream())) {
				file = sr.ReadToEnd();
			}
			var contentsToWriteToFile = JsonConvert.SerializeObject(file);
			TextWriter writer = new StreamWriter("test.json", false);
			writer.Write(contentsToWriteToFile);
		}
