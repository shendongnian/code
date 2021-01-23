        public static bool ValidateXmlFromXsd(string xml, string xsdFile)
        {
            
            bool returned = false;
            XmlValidatingReader reader = null;
            XmlSchemaCollection myschema = new XmlSchemaCollection();
            ValidationEventHandler eventHandler = new ValidationEventHandler(ShowCompileErrors);
            try
            {
                XmlParserContext context = new XmlParserContext(null, null, "", XmlSpace.None);
                reader = new XmlValidatingReader(xml, XmlNodeType.Element, context);
                myschema.Add("urn:schemas-microsoft-com:xml-msdata", xsdFile);
                reader.ValidationType = ValidationType.Schema;
                reader.Schemas.Add(myschema);
                while (reader.Read()) { }
                Console.WriteLine("Completed validating xmlfragment");
                returned = true;
            }
            catch (XmlException XmlExp)
            {
                Console.WriteLine(XmlExp.Message);
            }
            catch (XmlSchemaException XmlSchExp)
            {
                Console.WriteLine(XmlSchExp.Message);
            }
            catch (Exception GenExp)
            {
                Console.WriteLine(GenExp.Message);
            }
            finally
            {
                Console.Read();
            }
            return returned;
        }
