            public override string Process(string UserName,string Password)
        {
            string uri = "https://serviceURL";
            HttpWebRequest req = (HttpWebRequest)WebRequest.CreateDefault(new Uri(uri));
            req.ContentType = "application/soap+xml; charset=utf-8";            
            req.Method = "POST";
            string soapRequest = BuildSoapRequest(UserName,Password);
            StreamWriter stm = new StreamWriter(req.GetRequestStream(), Encoding.UTF8);
            stm.Write(soapRequest);
            stm.Close();
            try
            {
                HttpWebResponse wr = (HttpWebResponse)req.GetResponse();
                StreamReader srd = new StreamReader(wr.GetResponseStream());
                string response = srd.ReadToEnd();
                return ExtractResponse(response);
            }
            catch (WebException e)
            {
                string error = "";
                HttpWebResponse errRsp = (HttpWebResponse)e.Response;
                if (errRsp != null)
                {
                    using (StreamReader rdr = new StreamReader(errRsp.GetResponseStream()))
                    {
                        string line;
                        while ((line = rdr.ReadLine()) != null)
                        {
                            error += line;
                        }
                    }
                }
                throw new Exception(e.Message + "<br/> " + error);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
		private string BuildSoapRequest(string UserName,string Password)
        {
			StringBuilder soapRequest = new StringBuilder();
			
			soapRequest.Append("<soap:Envelope xmlns:cor=\"http://www.caqh.org/SOAP/WSDL/CORERule2.2.0.xsd\" xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:tem=\"http://tempuri.org/\">");
			soapRequest.Append("<soap:Header>");
			soapRequest.Append("<wsse:Security xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\">");
			soapRequest.Append("<wsse:UsernameToken>");
			soapRequest.Append("<wsse:Username>" + UserName + "</wsse:Username>");
			soapRequest.Append("<wsse:Password>" + Password + "</wsse:Password>");
			soapRequest.Append("</wsse:UsernameToken>");
			soapRequest.Append("</wsse:Security>");
			soapRequest.Append("</soap:Header>");
			soapRequest.Append("<soap:Body>");
			soapRequest.Append("</soap:Body>");
			soapRequest.Append("</soap:Envelope>");
			
			return soapRequest.ToString();
        }
		
		 private static string ExtractResponse(string soap)
        {
		
		}
