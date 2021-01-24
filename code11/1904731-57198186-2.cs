       var t = @"<document author=""paul@prescod.net"">
    <para>This is a paragraph <footnote>(better than the one under there)</footnote>.</para>
    <para>Ha! I made you say ""underwear"".</para>
    </document>";
    
        var xmlTextReader = XmlTextReader.Create(new StringReader(t));
        
        Visit(xmlTextReader, (XmlNodeType nodeType, XmlReader element) =>
        {
            switch (nodeType)
            {
                case XmlNodeType.Element:
                    Console.WriteLine();
                    Console.Write(new string('\t', element.Depth));
                    Console.Write("(" + element.Name);
                    break;
                case XmlNodeType.Text:
                    if(!string.IsNullOrEmpty(element.Value))
                    {
                        Console.Write(@" """ + element.Value.Replace(@"""", @"\""") + @"""");
                    }
                    break;
                case XmlNodeType.EndElement:
                    Console.Write(")");
                    break;
                case XmlNodeType.Attribute:
                    Console.Write(" " + element.Name + @": """ + element.Value.Replace(@"""",@"\""") + @"""");
                    break;
            }
        });
    ...
    
    public static void Visit(XmlReader xmlReader, Action<XmlNodeType, XmlReader> visitor)
    {
        while (xmlReader.Read())
        {
            visitor(xmlReader.NodeType, xmlReader);
    
            if (xmlReader.NodeType == XmlNodeType.Element)
            {
                while (xmlReader.MoveToNextAttribute())
                {
                    visitor(xmlReader.NodeType, xmlReader);
                }
            }
        }
    }
