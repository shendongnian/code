    /// <summary>
    /// The XmlSerializer doesn't know how to serialize dictionaries and will refuse
    /// to serialize anything that implements IDictionary.  This class can be used
    /// to temporarily wrap a dictionary for the serialization process.
    /// </summary>
    [XmlRoot("DICTIONARY")]
    public class SerializableDictionaryWrapper<TKey, TValue> : IXmlSerializable
    {
      #region Data
      private IDictionary<TKey, TValue> m_dictionary = null;
      #endregion
      #region Properties
      /// <summary>
      /// Gets or sets the wrapped dictionary.
      /// </summary>
      /// <value>The wrapped dictionary.</value>
      public IDictionary<TKey, TValue> WrappedDictionary
      {
        get { return m_dictionary; }
        set { m_dictionary = value; }
      }
      #endregion
      #region Constructors
      /// <summary>
      /// 
      /// </summary>
      public SerializableDictionaryWrapper()
      {
      }
      /// <summary>
      /// 
      /// </summary>
      /// <param name="dict"></param>
      public SerializableDictionaryWrapper(IDictionary<TKey, TValue> dict)
      {
        m_dictionary = dict;
      }
      #endregion
      #region IXmlSerializable Members
      /// <summary>
      /// This property is reserved, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute"></see> to the class instead.
      /// </summary>
      /// <returns>
      /// An <see cref="T:System.Xml.Schema.XmlSchema"></see> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"></see> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"></see> method.
      /// </returns>
      public System.Xml.Schema.XmlSchema GetSchema()
      {
        return null;
      }
      /// <summary>
      /// Generates an object from its XML representation.
      /// </summary>
      /// <param name="reader">The <see cref="T:System.Xml.XmlReader"></see> stream from which the object is deserialized.</param>
      public void ReadXml(System.Xml.XmlReader reader)
      {
        XmlSerializer key_serializer = new XmlSerializer(typeof(TKey));
        XmlSerializer value_serializer = new XmlSerializer(typeof(TValue));
        bool was_empty = reader.IsEmptyElement;
        m_dictionary = null;
        string type_name = reader.GetAttribute("type");
        if (type_name != null)
        {
          Type type = Type.GetType(type_name, false);
          if (type != null)
          {
            m_dictionary = Activator.CreateInstance(type) as IDictionary<TKey, TValue>;
          }
        }
        if (m_dictionary == null)
        {
          m_dictionary = new Dictionary<TKey, TValue>();
        }
        reader.Read();
        if (was_empty)
        {
          return;
        }
        while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
        {
          reader.ReadStartElement("item");
          reader.ReadStartElement("key");
          TKey key = (TKey)key_serializer.Deserialize(reader);
          reader.ReadEndElement();
          reader.ReadStartElement("value");
          TValue value = (TValue)value_serializer.Deserialize(reader);
          reader.ReadEndElement();
          m_dictionary.Add(key, value);
          reader.ReadEndElement();
          reader.MoveToContent();
        }
        reader.ReadEndElement();
      }
      /// <summary>
      /// Converts an object into its XML representation.
      /// </summary>
      /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"></see> stream to which the object is serialized.</param>
      public void WriteXml(System.Xml.XmlWriter writer)
      {
        XmlSerializer key_serializer = new XmlSerializer(typeof(TKey));
        XmlSerializer value_serializer = new XmlSerializer(typeof(TValue));
        writer.WriteAttributeString("type", m_dictionary.GetType().AssemblyQualifiedName);
        foreach (TKey key in m_dictionary.Keys)
        {
          writer.WriteStartElement("item");
          writer.WriteStartElement("key");
          key_serializer.Serialize(writer, key);
          writer.WriteEndElement();
          writer.WriteStartElement("value");
          TValue value = m_dictionary[key];
          value_serializer.Serialize(writer, value);
          writer.WriteEndElement();
          writer.WriteEndElement();
        }
      }
      #endregion
    };
