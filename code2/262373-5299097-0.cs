I would use recursion for this. Personally I would have a function that returns a TreeNode and if the current node contain child element nodes then calls itself such as:
    static class XmlProcessor
    {
        public static TreeNode ProcessXml(XmlReader reader)
        {
            // Move to first element
            while(reader.Read() && reader.NodeType != XmlNodeType.Element){}
            return ParseNode(reader);
        }
        private static TreeNode ParseNode(XmlReader reader)
        {
            if (reader.NodeType == XmlNodeType.Text) return new TreeNode(reader.Value);
            if (reader.IsEmptyElement) return new TreeNode(reader.Name);
            TreeNode current = new TreeNode(reader.LocalName);
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    current.Nodes.Add(ParseNode(reader));
                }
                else if (reader.NodeType == XmlNodeType.EndElement)
                {
                    return current;
                }
            }
            return current;
        }
    }
