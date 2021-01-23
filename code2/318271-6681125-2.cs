        public static string GetXmlString(XmlDocument doc)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            doc.WriteTo(xw);
            return sw.ToString();
        }
        public static void Handle_Document(XmlDocument doc)
        {
            MessageBox.Show(GetXmlString(doc));
        }
