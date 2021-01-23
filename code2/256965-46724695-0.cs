     private static void SetPrefix(string prefix, XmlNode node)
        {
            node.Prefix = prefix;
            foreach (XmlNode n in node.ChildNodes)
            {
                //if (node.ParentNode != null)
                //{
                if (n.Name.Contains("QualifyingProperties"))
                {
                    break;
                }
                //}
                SetPrefix(prefix, n);
            }
        }
