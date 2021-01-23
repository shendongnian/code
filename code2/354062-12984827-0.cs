    public class CachedRootXmlSerializer : XmlSerializer
    {
        private static Dictionary<int, XmlTypeMapping> rootMapCache = new Dictionary<int,XmlTypeMapping>();
        private static XmlTypeMapping GetXmlTypeMappingFromRoot(Type type, XmlRootAttribute xmlRootAttribute)
        {
            XmlTypeMapping result = null;
            int hash = 17;
            unchecked
            {
                hash = hash * 31 + type.GUID.GetHashCode();
                hash = hash * 31 + xmlRootAttribute.GetHashCode();
            }
            lock (rootMapCache)
            {
                if (!rootMapCache.ContainsKey(hash))
                {
                    XmlReflectionImporter importer = new XmlReflectionImporter(null, null);
                    rootMapCache[hash] = importer.ImportTypeMapping(type, xmlRootAttribute, null);
                }
                result = rootMapCache[hash];
            }
            return result;
        }
        CachedRootXmlSerializer(Type type, XmlRootAttribute xmlRootAttribute)
            : base(GetXmlTypeMappingFromRoot(type, xmlRootAttribute))
        {
        }
    }
