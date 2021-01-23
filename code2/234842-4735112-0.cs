    private string strLogger = null;
        public bool ValidateXml(string path2XMLFile, string path2XSDFile)
        {
            bool isValidFile = false;
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas.Add(null, path2XSDFile);
                settings.ValidationEventHandler += new ValidationEventHandler(settings_ValidationEventHandler);
                XmlReader reader = XmlReader.Create(path2XMLFile, settings);
                while (reader.Read()) ;
                if (String.IsNullOrEmpty(strLogger))
                {
                    isValidFile = true;
                }                
            }
            catch (Exception ex)
            {
                LoggingHandler.Log(ex);
            }
            return isValidFile;
        }
        private void settings_ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            strLogger += System.Environment.NewLine + "Validation Error Message  = [" + e.Message + "], " + "Validation Error Severity = [" + e.Severity + "], " + System.Environment.NewLine;
        } 
