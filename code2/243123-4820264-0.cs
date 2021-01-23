    static void Main()
    {
        string value = "Steet,<BR> </BR> City";
        XElement address = new XElement("Address", ParseFragment(value));
        Console.WriteLine(address);
    }
    static IEnumerable<XNode> ParseFragment(string fragment)
    {
        using (StringReader sr = new StringReader(fragment))
        {
            using (XmlReader xr = XmlReader.Create(sr, new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Fragment }))
            {
                xr.Read();
                XNode node;
                while (!xr.EOF && (node = XNode.ReadFrom(xr)) != null)
                {
                    yield return node;
                }
            }
        }
    }
