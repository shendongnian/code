    public interface IXmlDocumentFactory<T>
    {
        XmlDocument Create();                    //serializes just the data
        IXmlDocumentFactory<T> WithSchema(XmlSchema schema);    //serializes data and includes schema
    }
    public class DocumentFactory<T> : IXmlDocumentFactory<T>
    {
        private XmlSchema _schema;
        private T _data;
        public DocumentFactory(T data)
        {
            _data = data;
        }
        public IXmlDocumentFactory<T> WithSchema(XmlSchema schema)
        {
            _schema = schema;
            return this;
        }
        public XmlDocument Create()
        {
            if (_schema != null)
            {
                //..use schema/data
                return new XmlDocument();
            }
            else //use data
                return new XmlDocument();
        }
        public static IXmlDocumentFactory<T> From(T data)
        {
            return new DocumentFactory<T>(data);
        }
    }
