    public XDocument Upload(string imageAsBase64String)
    {
        XDocument result = null;
        using (var webClient = new WebClient())
        {
            var values = new NameValueCollection
                {
                    { "key", key },
                    { "image", imageAsBase64String }
                };
            byte[] response = webClient.UploadValues("http://api.imgur.com/2/upload.xml", "POST", values);
            result = XDocument.Load(System.Xml.XmlReader.Create(new MemoryStream(response)));
        }
        return result;
    }
