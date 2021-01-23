    public static bool XmlSerialize<T>(this T item, string fileName)
            {
                return item.XmlSerialize(fileName, true);
            }
            public static bool XmlSerialize<T>(this T item, string fileName, bool removeNamespaces)
            {
                object locker = new object();
    
                XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
                xmlns.Add(string.Empty, string.Empty);
    
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
    
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;
    
                lock (locker)
                {
                    using (XmlWriter writer = XmlWriter.Create(fileName, settings))
                    {
                        if (removeNamespaces)
                        {
                            xmlSerializer.Serialize(writer, item, xmlns);
                        }
                        else { xmlSerializer.Serialize(writer, item); }
    
                        writer.Close();
                    }
                }
    
                return true;
            }
            public static T XmlDeserialize<T>(this string s)
            {
                object locker = new object();
                StringReader stringReader = new StringReader(s);
                XmlTextReader reader = new XmlTextReader(stringReader);
                try
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    lock (locker)
                    {
                        T item = (T)xmlSerializer.Deserialize(reader);
                        reader.Close();
                        return item;
                    }
                }
                finally
                {
                    if (reader != null)
                    { reader.Close(); }
                }
            }
            public static T XmlDeserialize<T>(this FileInfo fileInfo)
            {
                string xml = string.Empty;
                using (FileStream fs = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        return sr.ReadToEnd().XmlDeserialize<T>();
                    }
                }
            }
