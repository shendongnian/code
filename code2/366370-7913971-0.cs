            using (var stream = new MemoryStream())
            {
                serializer.Serialize(stream, value);
                stream.Position = 0;
                using (XmlReader reader = XmlReader.Create(stream))
                {
                    XElement element = XElement.Load(reader);
                }
            }
