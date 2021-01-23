    /// <summary>
    /// Converts this instance to XML using the <see cref="DataContractSerializer"/>.
    /// </summary>
    /// <typeparam name="TSerializable">
    /// A type that is serializable using the <see cref="DataContractSerializer"/>.
    /// </typeparam>
    /// <param name="value">
    /// The object to be serialized to XML.
    /// </param>
    /// <returns>
    /// Formatted XML representing this instance. Does not include the XML declaration.
    /// </returns>
    public static string ToXml<TSerializable>(this TSerializable value)
    {
        var serializer = new DataContractSerializer(typeof(TSerializable));
        var output = new StringWriter();
        using (var writer = new XmlTextWriter(output) { Formatting = Formatting.Indented })
        {
            serializer.WriteObject(writer, value);
        }
        return output.GetStringBuilder().ToString();
    }
    /// <summary>
    /// Converts this instance to XML using the <see cref="DataContractSerializer"/> and writes it to the specified file.
    /// </summary>
    /// <typeparam name="TSerializable">
    /// A type that is serializable using the <see cref="DataContractSerializer"/>.
    /// </typeparam>
    /// <param name="value">
    /// The object to be serialized to XML.
    /// </param>
    /// <param name="filePath">Path of the file to write to.</param>
    public static void WriteXml<TSerializable>(this TSerializable value, string filePath)
    {
        var serializer = new DataContractSerializer(typeof(TSerializable));
        using (var writer = XmlWriter.Create(filePath, new XmlWriterSettings { Indent = true }))
        {
            serializer.WriteObject(writer, value);
        }
    }
    /// <summary>
    /// Creates from an instance of the specified class from XML.
    /// </summary>
    /// <typeparam name="TSerializable">The type of the serializable object.</typeparam>
    /// <param name="xml">The XML representation of the instance.</param>
    /// <returns>An instance created from the XML input.</returns>
    public static TSerializable CreateFromXml<TSerializable>(string xml)
    {
        var serializer = new DataContractSerializer(typeof(TSerializable));
        using (var stringReader = new StringReader(xml))
        using (var reader = XmlReader.Create(stringReader))
        {
            return (TSerializable)serializer.ReadObject(reader);
        }
    }
    /// <summary>
    /// Creates from an instance of the specified class from the specified XML file.
    /// </summary>
    /// <param name="filePath">
    /// Path to the XML file.
    /// </param>
    /// <typeparam name="TSerializable">
    /// The type of the serializable object.
    /// </typeparam>
    /// <returns>
    /// An instance created from the XML input.
    /// </returns>
    public static TSerializable CreateFromXmlFile<TSerializable>(string filePath)
    {
        var serializer = new DataContractSerializer(typeof(TSerializable));
        using (var reader = XmlReader.Create(filePath))
        {
            return (TSerializable)serializer.ReadObject(reader);
        }
    }
    public static T LoadJson<T>(Stream stream) where T : class
    {
        var serializer = new DataContractJsonSerializer(typeof(T));
        object readObject = serializer.ReadObject(stream);
        return (T)readObject;
    }
    public static void WriteJson<T>(this T value, Stream stream) where T : class
    {
        var serializer = new DataContractJsonSerializer(typeof(T));
        serializer.WriteObject(stream, value);
    }
