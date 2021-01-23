    namespace SerializeDictionary
    {
        using System;
        using System.Collections.Generic;
        using System.Runtime.Serialization;
        using System.Xml;
        using System.Xml.Schema;
        using System.Xml.Serialization;
    
    
        /// <summary>
        /// Represents an XML serializable collection of keys and values.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        [Serializable]
        [XmlRoot("dictionary")]
        public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
        {
            /// <summary>
            /// The default XML tag name for an item.
            /// </summary>
            private const string DEFAULTITEMTAG = "item";
    
            /// <summary>
            /// The default XML tag name for a key.
            /// </summary>
            private const string DEFAULTKEYTAG = "key";
    
            /// <summary>
            /// The default XML tag name for a value.
            /// </summary>
            private const string DEFAULTVALUETAG = "value";
    
            /// <summary>
            /// The XML serializer for the key type.
            /// </summary>
            private static readonly XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            /// <summary>
            /// The XML serializer for the value type.
            /// </summary>
            private static readonly XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            /// <summary>
            /// Initializes a new instance of the
            /// <see cref="SerializableDictionary&lt;TKey, TValue&gt;"/> class.
            /// </summary>
            public SerializableDictionary()
                : base()
            {
            }
    
            /// <summary>
            /// Initializes a new instance of the
            /// <see cref="SerializableDictionary&lt;TKey, TValue&gt;"/> class.
            /// </summary>
            /// <param name="info">A
            ///   <see cref="T:System.Runtime.Serialization.SerializationInfo"/> object
            ///   containing the information required to serialize the
            ///   <see cref="T:System.Collections.Generic.Dictionary`2"/>.
            /// </param>
            /// <param name="context">A
            ///   <see cref="T:System.Runtime.Serialization.StreamingContext"/> structure
            ///   containing the source and destination of the serialized stream
            ///   associated with the
            ///   <see cref="T:System.Collections.Generic.Dictionary`2"/>.
            /// </param>
            protected SerializableDictionary(
               SerializationInfo info,
               StreamingContext context)
                : base(info, context)
            {
            }
    
            /// <summary>
            /// Gets the XML tag name for an item.
            /// </summary>
            protected virtual string ItemTagName
            {
                get
                {
                    return DEFAULTITEMTAG;
                }
            }
    
            /// <summary>
            /// Gets the XML tag name for a key.
            /// </summary>
            protected virtual string KeyTagName
            {
                get
                {
                    return DEFAULTKEYTAG;
                }
            }
    
            /// <summary>
            /// Gets the XML tag name for a value.
            /// </summary>
            protected virtual string ValueTagName
            {
                get
                {
                    return DEFAULTVALUETAG;
                }
            }
    
            /// <summary>
            /// Gets the XML schema for the XML serialization.
            /// </summary>
            /// <returns>An XML schema for the serialized object.</returns>
            public XmlSchema GetSchema()
            {
                return null;
            }
    
            /// <summary>
            /// Deserializes the object from XML.
            /// </summary>
            /// <param name="reader">The XML representation of the object.</param>
            public void ReadXml(XmlReader reader)
            {
                var wasEmpty = reader.IsEmptyElement;
    
                reader.Read();
    
                if (wasEmpty)
                {
                    return;
                }
    
                try
                {
                    while (reader.NodeType != XmlNodeType.EndElement)
                    {
                        reader.ReadStartElement(this.ItemTagName);
                        try
                        {
                            TKey key;
                            TValue value;
    
                            reader.ReadStartElement(this.KeyTagName);
                            try
                            {
                                key = (TKey)keySerializer.Deserialize(reader);
                            }
                            finally
                            {
                                reader.ReadEndElement();
                            }
    
                            reader.ReadStartElement(this.ValueTagName);
                            try
                            {
                                value = (TValue)valueSerializer.Deserialize(reader);
                            }
                            finally
                            {
                                reader.ReadEndElement();
                            }
    
                            this.Add(key, value);
                        }
                        finally
                        {
                            reader.ReadEndElement();
                        }
    
                        reader.MoveToContent();
                    }
                }
                finally
                {
                    reader.ReadEndElement();
                }
            }
    
            /// <summary>
            /// Serializes this instance to XML.
            /// </summary>
            /// <param name="writer">The writer to serialize to.</param>
            public void WriteXml(XmlWriter writer)
            {
                foreach (var keyValuePair in this)
                {
                    writer.WriteStartElement(this.ItemTagName);
                    try
                    {
                        writer.WriteStartElement(this.KeyTagName);
                        try
                        {
                            keySerializer.Serialize(writer, keyValuePair.Key);
                        }
                        finally
                        {
                            writer.WriteEndElement();
                        }
    
                        writer.WriteStartElement(this.ValueTagName);
                        try
                        {
                            valueSerializer.Serialize(writer, keyValuePair.Value);
                        }
                        finally
                        {
                            writer.WriteEndElement();
                        }
                    }
                    finally
                    {
                        writer.WriteEndElement();
                    }
                }
            }
        }
    }
