    using System;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    public partial class add_xml_linq : System.Web.UI.Page
    {
      protected void Page_Load(object sender, EventArgs e)
      {
        XDocument xmldoc = XDocument.Load(Server.MapPath("yourXMLFile.xml"));
        XElement parentXElement = xmldoc.XPathSelectElement("yourRoot");
        XElement newXElement = new XElement("test", "abc");
    
        // a) append element
        parentXElement.Add(newXElement);
    
        // b) prepend element
        parentXElement.AddFirst(newXElement);
    
        // c) insert before element
        refXElement.AddBeforeSelf(newXElement);
    
        // d) insert after element
        refXElement.AddAfterSelf(newXElement);
    
        xmldoc.Save(Server.MapPath("yourXMLFile.xml"));
      }
    }
