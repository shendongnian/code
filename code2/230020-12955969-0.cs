			HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("https://www.yoururl.com");
			WebResponse response = myReq.GetResponse();
			Stream responseStream = response.GetResponseStream();
			XmlTextReader reader = new XmlTextReader(responseStream);
			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Text)
					Console.WriteLine("{0}", reader.Value.Trim());
			}
						
			Console.ReadLine();
