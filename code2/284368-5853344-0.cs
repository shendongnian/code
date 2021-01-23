    using System.Linq;
    using System.Xml.Linq;
    
    // [...]
    var codeKey = "0";
    var name = "Codes - Bus Type";
    
    var doc = XDocument.Load("bla");
    var code = doc.Descendants().Where(
    		d => d.Name == "CodeText" &&
    		d.Parent.Attribute("Name").Value == name &&
    		d.Attribute("CodeValue").Value == codeKey).FirstOrDefault().Value;
