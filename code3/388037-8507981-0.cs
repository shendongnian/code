        private TreeNode TNGroups(XElement xml)
        {
            TreeNode node = new TreeNode();
            foreach (XElement group in xml.Descendants("Group"))
            {
                TreeNode tnGroup = new TreeNode(group.Element("GroupName").Value);
                node.Nodes.Add(tnGroup);
                foreach (XElement subgroup in group.Elements("SubGroup"))
                {
                    TreeNode tnSubGroup = new TreeNode(subgroup.Element("SubGroupName").Value);
                    tnGroup.Nodes.Add(tnSubGroup);
                }
            }
            return node;
        }
You would call it like this myTreeView.Nodes.Add(TNGroups(groupsXML)).
To load you XML into an element just use XElement.Load.
