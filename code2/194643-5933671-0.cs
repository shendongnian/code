                StringBuilder sb = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(sb);
                XmlSerializer serializer = new XmlSerializer(typeof(WSOpenShipments), myns);
                var ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, "");
                serializer.Serialize(writer, OS, ns);
                xmlString = sb.ToString();
