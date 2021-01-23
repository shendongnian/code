    class Request
    {
        public static void Execute(string XML)
        {
            try
            {
                HttpWebRequest request = CreateWebRequest();
                XmlDocument soapEnvelopeXml = new XmlDocument();
                soapEnvelopeXml.LoadXml(AppendEnvelope(AddNamespace(XML)));
                using (Stream stream = request.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        string soapResult = rd.ReadToEnd();
                        Console.WriteLine(soapResult);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
       
        private static HttpWebRequest CreateWebRequest()
        {
            string ICMURL = System.Configuration.ConfigurationManager.AppSettings.Get("ICMUrl");
            HttpWebRequest webRequest = null;
            try
            {
                webRequest = (HttpWebRequest)WebRequest.Create(ICMURL);
                webRequest.Headers.Add(@"SOAP:Action");
                webRequest.ContentType = "text/xml;charset=\"utf-8\"";
                webRequest.Accept = "text/xml";
                webRequest.Method = "POST";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return webRequest;
        }
        private static string AddNamespace(string XML)
        {
            string result = string.Empty;
            try
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(XML);
                XmlElement temproot = xdoc.CreateElement("ws", "Request", "http://example.com/");
                temproot.InnerXml = xdoc.DocumentElement.InnerXml;
                result = temproot.OuterXml;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return result;
        }
        private static string AppendEnvelope(string data)
        {
            string head= @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" ><soapenv:Header/><soapenv:Body>";
            string end = @"</soapenv:Body></soapenv:Envelope>";
            return head + data + end;
        }
    }
