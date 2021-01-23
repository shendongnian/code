    using System;
    using System.Xml;
    using System.Linq;
    using NUnit.Framework;
    [TestFixture]
    public class XmlConvert
    {
        [TestCase("input.xml", "output.xml")]
        public void LeafsToAttributes(string inputxml, string outputxml)
        {
            var doc = new XmlDocument();
            doc.Load(inputxml);
            ParseLeafs(doc.DocumentElement);
            doc.Save(outputxml);
        }
        private void ParseLeafs(XmlNode parent)
        {
            var children = parent.ChildNodes.Cast<XmlNode>().ToArray();
            foreach (XmlNode child in children)
                if (child.NodeType == XmlNodeType.Element
                    && child.Attributes.Count == 0
                    && child.ChildNodes.Count == 1
                    && child.ChildNodes[0].NodeType == XmlNodeType.Text
                    && parent.Attributes[child.Name] == null)
                {
                    AddAttribute(parent, child.Name, child.InnerXml);
                    parent.RemoveChild(child);
                }
                else ParseLeafs(child);
            // show no closing tag, if not necessary
            if (parent.NodeType == XmlNodeType.Element
                && parent.ChildNodes.Count == 0)
                (parent as XmlElement).IsEmpty = true;
        }
        private XmlAttribute AddAttribute(XmlNode node, string name, string value)
        {
            var attr = node.OwnerDocument.CreateAttribute(name);
            attr.Value = value;
            node.Attributes.Append(attr);
            return attr;
        }
    }
