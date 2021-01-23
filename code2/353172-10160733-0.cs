    void IXmlSerializable.WriteXml(XmlWriter writer) {
            writer.WriteAttributeString("xmlns:me", "member.com");
            writer.WriteAttributeString("xmlns", "www.123.com");
            writer.WriteElementString(XML_MEMBER_PREFIX, "Member1.5",
                                      XML_MEMBER_NS, Member1);
            writer.WriteElementString(XML_MEMBER_PREFIX, "Member2.5",
                                      XML_MEMBER_NS, Member2.ToString());
            writer.WriteElementString(XML_PREFIX, "Member3.5", XML_NS, Member3);
        }
