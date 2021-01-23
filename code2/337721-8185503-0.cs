        private static string GetXmlMapping()
        {
            Stream xmlStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Mpicorp.SytelineDataModel.Generated.SytelineMapping.xml");
            StreamReader streamReader = new StreamReader(xmlStream);
            return streamReader.ReadToEnd();
        }
