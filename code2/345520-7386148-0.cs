    public class Foo : IXmlSerializable
    {
        [XmlComment(Value = "The application version, NOT the file version!")]
        public string Version { get; set; }
        public string Name { get; set; }
    
    
        public void WriteXml(XmlWriter writer)
        {
            var properties = GetType().GetProperties();
                
            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.IsDefined(typeof(XmlCommentAttribute), false))
                {
                    writer.WriteComment(
                        propertyInfo.GetCustomAttributes(typeof(XmlCommentAttribute), false)
                            .Cast<XmlCommentAttribute>().Single().Value);
                }
    
                writer.WriteElementString(propertyInfo.Name, propertyInfo.GetValue(this, null).ToString());
            }
        }
        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }
    
        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }
    }
    
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class XmlCommentAttribute : Attribute
    {
        public string Value { get; set; }
    }
