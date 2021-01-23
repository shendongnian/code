           //get the input file here - You can replace this to your local file
            var httpRequest = HttpContext.Current.Request;
    
            if (httpRequest.Files.Count > 0)
            {
                var postedFile = httpRequest.Files[0];
    
                //sete the xsd schema path                    
                string xsdPath = HttpContext.Current.Server.MapPath("~/XSD/MyFile.xsd");
    
                //set the XSD schema here
                var schema = new XmlSchemaSet();
                schema.Add("", xsdPath);
                var Message = "";
    
                //validate the xml schema here
                XDocument document = XDocument.Load(postedFile.InputStream, LoadOptions.PreserveWhitespace | LoadOptions.SetLineInfo | LoadOptions.SetBaseUri);
                //create a lists to add the error records
                List<string> lstErrors = new List<string>();
                document.Validate(schema, ValidationEventHandler);
    
                //validate all the errors
                document.Validate(schema, (sender, args) =>
                 {
                     IXmlLineInfo item = sender as IXmlLineInfo;
                     if (item != null && item.HasLineInfo())
                     {
                         //capture all the details needed here seperated by colons
                         Message = item.LineNumber + ";" +
                         (((System.Xml.Linq.XObject)item).Parent.Element("id")).Value + ";" +
                         ((System.Xml.Linq.XElement)item).Name.LocalName + ";" +
                         args.Message + Environment.NewLine;
                         //add the error to a list
                         lstErrors.Add(Message);
                     }
                 });
            }
