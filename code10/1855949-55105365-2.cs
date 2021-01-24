    public class CallbackXamlService
    {
        // Default settings that XamlService uses
        public XmlWriterSettings XmlWriterSettings { get; set; }
            = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true };
        public event EventHandler<XamlObjectEventArgs> BeforeDeserializing;
        public event EventHandler<XamlObjectEventArgs> AfterDeserializing;
        public event EventHandler<XamlObjectEventArgs> BeforeSerializing;
        // AfterSerializing event doesn't seem to be easily possible, see below
        public object LoadXaml(TextReader textReader)
        {
            var settings = new XamlObjectWriterSettings
            {
                BeforePropertiesHandler = (s, e) => BeforeDeserializing?.Invoke(this, e),
                AfterPropertiesHandler = (s, e) => AfterDeserializing?.Invoke(this, e)
            };
            using (var xmlReader = XmlReader.Create(textReader))
            using (var xamlReader = new XamlXmlReader(xmlReader))
            using (var xamlWriter = new XamlObjectWriter(xamlReader.SchemaContext, settings))
            {
                XamlServices.Transform(xamlReader, xamlWriter);
                return xamlWriter.Result;
            }
        }
        public string SaveXaml(object instance)
        {
            var stringBuilder = new StringBuilder();
            using (var textWriter = new StringWriter(stringBuilder))
                SaveXaml(textWriter, instance);
            return stringBuilder.ToString();
        }
        public void SaveXaml(TextWriter textWriter, object instance)
        {
            Action<object> beforeSerializing = (obj) => BeforeSerializing?.Invoke(this, new XamlObjectEventArgs(obj));
            // There are no equivalent callbacks on XamlObjectReaderSettings
            // Using a derived XamlObjectReader to track processed objects instead
            using (var xmlWriter = XmlWriter.Create(textWriter, XmlWriterSettings))
            using (var xamlXmlWriter = new XamlXmlWriter(xmlWriter, new XamlSchemaContext()))
            using (var xamlObjectReader = new CallbackXamlObjectReader(instance, xamlXmlWriter.SchemaContext, null, beforeSerializing))
            {
                XamlServices.Transform(xamlObjectReader, xamlXmlWriter);
                xmlWriter.Flush();
            }
        }
        private class CallbackXamlObjectReader : XamlObjectReader
        {
            public Action<object> BeforeSerializing { get; }
            //private Stack<object> instanceStack = new Stack<object>();
            public CallbackXamlObjectReader(object instance, XamlSchemaContext schemaContext, XamlObjectReaderSettings settings, Action<object> beforeSerializing)
                : base(instance, schemaContext, settings)
            {
                BeforeSerializing = beforeSerializing;
            }
            public override bool Read()
            {
                if (base.Read())
                {
                    if (NodeType == XamlNodeType.StartObject)
                    {
                        //instanceStack.Push(Instance);
                        BeforeSerializing?.Invoke(Instance);
                    }
                    // XamlObjectReader.Instance is not set on EndObject nodes
                    // EndObject nodes do not line up with StartObject nodes when types like arrays and dictionaries
                    // are involved, so using a stack to track the current instance doesn't always work.
                    // Don't know if there is a reliable way to fix this without possibly fragile special-casing,
                    // the XamlObjectReader internals are horrendously complex.
                    //else if (NodeType == XamlNodeType.EndObject)
                    //{
                    //    object instance = instanceStack.Pop();
                    //    AfterSerializing(instance);
                    //}
                    return true;
                }
                return false;
            }
        }
    }
