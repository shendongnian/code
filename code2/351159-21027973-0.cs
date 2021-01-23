    ...
    [XmlRoot(IsNullable = false, Namespace = "http://www.opengis.net/ows")]
    public partial class ExceptionReport
    {
        [XmlNamespaceDeclarations()]
        public XmlSerializerNamespaces xmlns
        {
           get
           {
               XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
               xmlns.Add("ows", "http://www.opengis.net/ows");
               return xmlns;
           }
           set
           { 
           }
       }
   
       ...
    }
