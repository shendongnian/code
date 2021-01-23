	            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
	            //req.Headers.Add("SOAPAction", "http://tempuri.org/IWebService/GetMessage");
				req.ProtocolVersion = HttpVersion.Version11;
	            req.ContentType = "text/xml;charset=\"utf-8\"";
	            req.Accept = "text/xml";
				req.KeepAlive = true;
				req.Method = "POST";
				
			
	            using (Stream stm = req.GetRequestStream())
	            {
	                using (StreamWriter stmw = new StreamWriter(stm))
						stmw.Write(soapStr);
	            }
	            using (StreamReader responseReader = new StreamReader(req.GetResponse().GetResponseStream()))
	            {
	                string result = responseReader.ReadToEnd();
	                ResultXML = XDocument.Parse(result);
	                ResultString = result;
						
	            }
        	}
