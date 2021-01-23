    private static void RecursivelySerialize(ref XmlWriter writer, Node sc) {
        writer.WriteStartElement("Node");
        writer.WriteElementString("SomeProperty", sc.SomeProperty);
        if (sc.Children.Count > 0) {
            writer.WriteStartElement("Nodes");
            foreach (Node scChild in sc.Children)
                RecursivelySerialize(ref writer, scChild);
            writer.WriteEndElement();
        }
        writer.WriteEndElement();
    }
