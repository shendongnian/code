        private string parseNode(TreeNode tn)
        {
            var sb = new StringBuilder();
            using (var writer = XmlWriter.Create(sb))
            {
                writer.WriteStartElement("xml");
                parseNode(tn, writer);
                writer.WriteEndElement();
            }
            return sb.ToString();
        }
        private void parseNode(TreeNode tn, XmlWriter writer)
        {
            if (tn.Nodes.Count > 0)
            {
                writer.WriteStartElement(tn.Text);
                foreach (TreeNode child in tn.Nodes)
                {
                    parseNode(child, writer);
                }
                writer.WriteEndElement();
            }
            else
            {
                writer.WriteString(tn.Text);
            }
        }
