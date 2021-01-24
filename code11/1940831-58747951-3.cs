    public static string ToCSV(string xmlTextDate, string xsltFile)
    {
      string result = string.Empty;
      var xpathDoc = new XPathDocument(xmlTextDate);
      var xsltTransform = new System.Xml.Xsl.XslCompiledTransform();
      xsltTransform.Load(xsltFile);
    
      using (MemoryStream ms = new MemoryStream())
      {
          var writer = new XmlTextWriter(ms, Encoding.UTF8);
          using (var rd = new StreamReader(ms))
          {
              var argList = new System.Xml.Xsl.XsltArgumentList();
              xsltTransform.Transform(xpathDoc, argList, writer);
              ms.Position = 0;
              result = rd.ReadToEnd();
          }
      }
      return result;
    }
