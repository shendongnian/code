     [System.Web.Http.HttpPost]
        public async void CreateJob(string filename)
        {
            string success = "false";
            try
            {
                //XDocument doc = XDocument.Load
                XmlSerializer xmls = new XmlSerializer(typeof(PdnaXmlParse));
                Stream reqStream = await Request.Content.ReadAsStreamAsync();
                PdnaXmlParse res = (PdnaXmlParse)xmls.Deserialize(new XmlTextReader(reqStream));
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
    }
