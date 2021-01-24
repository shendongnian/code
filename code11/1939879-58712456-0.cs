        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                StringWriter sw = new StringWriter();
                XmlTextWriter tx = new XmlTextWriter(sw);
                soapEnvelopeXml.WriteTo(tx);
                string str = sw.ToString();
                Console.WriteLine(soapEnvelopeXml.ToString());
                ASCIIEncoding Encode = new ASCIIEncoding();
                var arr = Encode.GetBytes(EncodeStringToBase64(str));
                stream.Write(arr, 0, arr.Length);
            }
        }
