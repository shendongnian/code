    [HttpPost("api/[controller]/ConnectWebHook")]
    public IActionResult ConnectWebHook() {
        Stream stream = Request.Body;
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(stream);
        var mgr = new XmlNamespaceManager(xmldoc.NameTable);
        mgr.AddNamespace("a", "http://www.docusign.net/API/3.0");
        XmlNode envelopeStatus = xmldoc.SelectSingleNode("//a:EnvelopeStatus", mgr);
        XmlNode envelopeId = envelopeStatus.SelectSingleNode("//a:EnvelopeID", mgr);
        XmlNode status = envelopeStatus.SelectSingleNode("./a:Status", mgr);
        var targetFileDirectory = @"\\my-network-share\";
        if (envelopeId != null) {
            System.IO.File.WriteAllText($"{targetFileDirectory}{envelopeId.InnerText}_{status.InnerText}_.xml", xmldoc.OuterXml);
        }
        if (status.InnerText == "Completed") {
            // Loop through the DocumentPDFs element, storing each document.
            XmlNode docs = xmldoc.SelectSingleNode("//a:DocumentPDFs", mgr);
            foreach (XmlNode doc in docs.ChildNodes) {
                string documentName = doc.ChildNodes[0].InnerText; // pdf.SelectSingleNode("//a:Name", mgr).InnerText;
                string documentId = doc.ChildNodes[2].InnerText; // pdf.SelectSingleNode("//a:DocumentID", mgr).InnerText;
                string byteStr = doc.ChildNodes[1].InnerText; // pdf.SelectSingleNode("//a:PDFBytes", mgr).InnerText;
                System.IO.File.WriteAllText($"{targetFileDirectory}{envelopeId.InnerText}_{documentId}_{documentName}", byteStr);
            }
        }
        return Ok();
    }
