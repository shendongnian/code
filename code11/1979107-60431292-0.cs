 c#
    static void WriteCredit(XmlWriter xml, string id, string number)
    {
        xml.WriteStartElement("CREDITS");
        xml.WriteStartElement("CREDIT");
        xml.WriteAttributeString("ID", id);
        xml.WriteElementString("D_number" + id, number);
        xml.WriteEndElement();
        xml.WriteEndElement();
    }
usage that writes to the console:
 c#
    using (var xml = XmlWriter.Create(Console.Out))
    {
        WriteCredit(xml, "1", "06");
    }
