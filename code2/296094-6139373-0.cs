    public interface IXmlDocumentFactory<T>
    {
        XmlDocument Create();                    //serializes just the data
        IXmlDocumentFactory<T> WithSchema(XmlSchema schema);    //serializes data and includes schema
    }
    public class DocumentFactory<T> : IXmlDocumentFactory<T>
    {
        private XmlSchema _schema;
        public IXmlDocumentFactory<T> WithSchema(XmlSchema schema)
        {
            _schema = schema;
            return this;
        }
        public XmlDocument Create()
        {
            if(_schema !=null)
            {
                //..use schema
                return new XmlDocument();
            }
            else
                return new XmlDocument();
        }
        public static IXmlDocumentFactory<T> Build()
        {
            return new DocumentFactory<T>();
        }
    }
