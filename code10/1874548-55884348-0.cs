        [HttpGet("values.{format}"), FormatFilter]
        public ActionResult TestObjectOutput()
        {
            string xml = DynamicXmlRawString();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
  
            return Ok(xmlDoc);
        }
        public static string DynamicXmlRawString()
        {
            return $@"<Result><DateTime>{DateTime.Now}</DateTime><User><Someone>12345678</Someone></User></Result>";
        }
   
           
