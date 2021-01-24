    public static partial class XmlSerializationHelper
    {
        public static string GetSoapXml<T>(this T obj, XName wrapperName, XmlSerializer serializer = null)
        {
            using (var textWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings() { Indent = true }; // For cosmetic purposes.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
				{
					xmlWriter.WriteStartElement(wrapperName.LocalName, wrapperName.NamespaceName);
                    (serializer ?? GetDefaultSoapSerializer(obj.GetType())).Serialize(xmlWriter, obj);
					xmlWriter.WriteEndElement();
				}
                return textWriter.ToString();
            }
        }
		static readonly Dictionary<Type, XmlSerializer> cache = new Dictionary<Type, XmlSerializer>();
		
		public static XmlSerializer GetDefaultSoapSerializer(Type type)
		{
			lock(cache)
			{
				if (cache.TryGetValue(type, out var serializer))
					return serializer;
				return cache[type] = new XmlSerializer(new SoapReflectionImporter().ImportTypeMapping(type));
			}
		}
	}
