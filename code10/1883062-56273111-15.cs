    public static partial class JsonExtensions
    {
        public static XDocument LoadXNode(string pathJson, string deserializeRootElementName)
        {
            using (var stream = File.OpenRead(pathJson))
                return LoadXNode(stream, deserializeRootElementName);
        }
        public static XDocument LoadXNode(Stream stream, string deserializeRootElementName)
        {
            // Let caller dispose the underlying streams.
            using (var textReader = new StreamReader(stream, Encoding.UTF8, true, 1024, true))
                return LoadXNode(textReader, deserializeRootElementName);
        }
        public static XDocument LoadXNode(TextReader textReader, string deserializeRootElementName)
        {
            var settings = new JsonSerializerSettings 
            { 
                Converters = { new XmlNodeConverter { DeserializeRootElementName = deserializeRootElementName } },
            };
            using (var jsonReader = new JsonTextReader(textReader) { CloseInput = false })
                return JsonSerializer.CreateDefault(settings).Deserialize<XDocument>(jsonReader);
        }
        public static void StreamJsonToXml(string pathJson, string pathXml, string deserializeRootElementName, SaveOptions saveOptions = SaveOptions.None)
        {
            var doc = LoadXNode(pathJson, deserializeRootElementName);
            doc.Save(pathXml, saveOptions);
        }
    }
