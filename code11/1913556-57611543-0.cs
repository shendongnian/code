			string ordohtml = "Ordo here...";
			string ordotext = "";
			
			string ordodate;
			DateTime dt = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day);
			ordodate = DateTime.Now.ToString("yyyyMMd");
			string ordourl = "https://1962ordo.today?date=" + ordodate;
			
			ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
			using (WebClient webClient = new WebClient()) {
				webClient.Headers["User-Agent"] = "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.2.6) Gecko/20100625 Firefox/3.6.6 (.NET CLR 3.5.30729)";
				webClient.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
				webClient.Headers["Accept-Language"] = "en-us,en;q=0.5";
				webClient.Headers["Accept-Encoding"] = "gzip,deflate";
				webClient.Headers["Accept-Charset"] = "ISO-8859-1,utf-8;q=0.7,*;q=0.7";
				StreamReader sr = new StreamReader(webClient.OpenRead(ordourl));
				ordohtml = sr.ReadToEnd();
                div_ordo = ordohtml.InnerHtml;
			};
