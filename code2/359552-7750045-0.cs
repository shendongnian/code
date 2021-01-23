    public static void DumpXml(XElement root, TextWriter writer)
    {
        if (root.HasElements)
        {
            foreach (var child in root.Elements())
            {
                DumpXml(child, writer);
            }
        }
        else
        {
            writer.WriteLine("{0}: {1}", root.Name, root.Value);
        }
        foreach (var attr in root.Attributes())
        {
            writer.WriteLine("{0}: {1}", attr.Name, attr.Value);
        }
    }
