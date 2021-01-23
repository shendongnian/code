    static void Main(string[] args)
        {
            string completeUrl = SERVICE_URL;
            WebRequest request = WebRequest.Create(completeUrl);
            request.Credentials = CredentialCache.DefaultCredentials;
            WebProxy proxyObject = new WebProxy(SERVICE_URL, true);
            request.Proxy = proxyObject;
            HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
            byte[] data;
            const int BUFFER_SIZE = 2048;
            int bytesRead;
            byte[] buffer = new byte[BUFFER_SIZE];
            using (MemoryStream mss = new MemoryStream())
            {
                using (BinaryReader readers = new
                BinaryReader(webResponse.GetResponseStream(), System.Text.Encoding.UTF8))
                {
                    while ((bytesRead = readers.Read(buffer, 0, BUFFER_SIZE)) > 0)
                    {
                        mss.Write(buffer, 0, bytesRead);
                    }
                    data = mss.ToArray();
                    System.Text.Encoding enc = System.Text.Encoding.GetEncoding("iso-8859-1");
                    string str = enc.GetString(data);
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.LoadXml(str);
                    XmlNode xmlList = xdoc.ChildNodes[1];
                    XmlNode item = xmlList.ChildNodes[1]; //this is your data : JVBERi0xLjUNCiXNzc3NDQoxIDAgb2JqDQo8PA0KL0NyZWF0b3IgKERvY3VtZW50UHJ
                    Base64Decode(item.InnerText.ToString());
                    Console.WirteLine("File successfully saved");
                    Console.ReadLine();
                }
            }
        }
        public static void Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            File.WriteAllBytes("pdf.pdf", base64EncodedBytes);
        }
