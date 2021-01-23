    [WebService(Namespace = "http://mynamespace/")]
    public class Service1 : System.Web.Services.WebService
    {
                [XmlNamespaceDeclarations]
                public XmlSerializerNamespaces xmlns
                {
                    get
                    {
                        XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
                        xsn.Add("me", "http://mynamespace/");
                        return xsn;
                    }
                    set { /* needed for xml serialization */ }
                }
    }
