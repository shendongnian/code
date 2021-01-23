    public class Validator
        {
            XmlSchemaSet schemaset;
            ILog logger;
            static Validator instance;
            static object lockObject = new Object();
    
            public static Validator Instance
            {
                get { return instance; }
            }
    
            public Validator(string schemaPath)
            {
                WarningAsErrors = true;
                logger = LogManager.GetLogger(GetType().Name);
                schemaset = new XmlSchemaSet();
                foreach (string s in Directory.GetFiles(schemaPath, "*.xsd"))
                {
                    schemaset.Add(XmlSchema.Read(XmlReader.Create(s),new ValidationEventHandler((ss,e)=>OnValidateReadSchema(ss,e))));
                }
                instance = this;
            }
    
            private void OnValidateReadSchema(object ss, ValidationEventArgs e)
            {
                if (e.Severity == XmlSeverityType.Error)
                    logger.Error(e.Message);
                else
                    logger.Warn(e.Message);
            }
            public bool WarningAsErrors { get; set; }
            private string FormatLineInfo(XmlSchemaException xmlSchemaException)
            {
                return string.Format(" Line:{0} Position:{1}", xmlSchemaException.LineNumber, xmlSchemaException.LinePosition);
            }
            protected void OnValidate(object _, ValidationEventArgs vae)
            {
                if (vae.Severity == XmlSeverityType.Error)
                    logger.Error(vae.Message);
                else
                    logger.Warn(vae.Message);
                if (vae.Severity == XmlSeverityType.Error || WarningAsErrors)
                    errors.AppendLine(vae.Message + FormatLineInfo(vae.Exception));
                else
                    warnings.AppendLine(vae.Message + FormatLineInfo(vae.Exception));
            }
    
            public string ErrorMessage { get; set; }
            public string WarningMessage { get; set; }
            StringBuilder errors, warnings;
            public void Validate(String doc)
            {
                lock (lockObject)
                {
                    errors = new StringBuilder();
                    warnings = new StringBuilder();
    
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.CloseInput = true;
                    settings.ValidationEventHandler += new ValidationEventHandler((o, e) => OnValidate(o, e));  // Your callback...
                    settings.ValidationType = ValidationType.Schema;
                    settings.Schemas.Add(schemaset);
                    settings.ValidationFlags =
                      XmlSchemaValidationFlags.ReportValidationWarnings |
                      XmlSchemaValidationFlags.ProcessIdentityConstraints |
                      XmlSchemaValidationFlags.ProcessInlineSchema |
                      XmlSchemaValidationFlags.ProcessSchemaLocation;
    
                    // Wrap document in an XmlNodeReader and run validation on top of that
                    try
                    {
                        using (XmlReader validatingReader = XmlReader.Create(new StringReader(doc), settings))
                        {
                            while (validatingReader.Read()) { /* just loop through document */ }
                        }
                    }
                    catch (XmlException e)
                    {
                        errors.AppendLine(string.Format("Error at line:{0} Posizione:{1}", e.LineNumber, e.LinePosition));
                    }
                    ErrorMessage = errors.ToString();
                    WarningMessage = warnings.ToString();
                }
            }
    
        }
