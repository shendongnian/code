       private void populateBaseNodes(XmlDocument docXML)
        {
            tView.Nodes.Clear(); // Clear
            tView.BeginUpdate();
            TreeNode treenode;
            XmlNodeList baseNodeList = docXML.ChildNodes;
            foreach (XmlNode xmlnode in baseNodeList)
            {
                string key = xmlnode.Name == null ? "" : xmlnode.Name.ToString();
                string value = xmlnode.Value == null ? xmlnode.Name.ToString() : xmlnode.Value.ToString();
                treenode = tView.Nodes.Add(key, value); // add it to the tree
                if (xmlnode.Attributes.Count > 0)
                {
                    foreach (XmlAttribute att in xmlnode.Attributes)
                    {
                        TreeNode tnode = new TreeNode();
                        string _name = att.Name;
                        string _value = att.Value.ToString();
                        tnode.Name= _name;
                        tnode.ForeColor = Color.Red;
                        tnode.Text= "<Attribute>:" +_name;
                        TreeNode _attvalue = new TreeNode();
                        _attvalue.Name = _name;
                        _attvalue.Text = _value;
                        _attvalue.ForeColor = Color.Purple;
                        tnode.Nodes.Add(_attvalue);
                        treenode.Nodes.Add(tnode);
                    }
                }
                AddChildNodes(xmlnode, treenode);
            }
            tView.EndUpdate();
            tView.Refresh();
        }
        private void AddChildNodes(XmlNode nodeact, TreeNode TreeNodeAct)
        {
            XmlNodeList ChildNodeList = nodeact.ChildNodes;
            TreeNode aux = null;
            if (nodeact.HasChildNodes)
            {
                //Recursive Call
                foreach (XmlNode xmlChildnode in nodeact.ChildNodes)
                {
                    //Add Actual Node & Properties
                    string Key = xmlChildnode.Name == null ? "" : xmlChildnode.Name.ToString();
                    string Value = xmlChildnode.Value == null ? xmlChildnode.Name.ToString() : xmlChildnode.Value.ToString();
                    aux = TreeNodeAct.Nodes.Add(Key, Value);
                    AddChildNodes(xmlChildnode, aux);
                    if (xmlChildnode.Attributes != null && xmlChildnode.Attributes.Count > 0)
                    {
                        foreach (XmlAttribute att in xmlChildnode.Attributes)
                        {
                            TreeNode tnode = new TreeNode();
                            string _name = att.Name;
                            string _value = att.Value.ToString();
                            tnode.Name = _name;
                            tnode.Text = "<Attribute>:" + _name;
                            tnode.ForeColor = Color.Red;
                            tnode.Text = "<Attribute>:" + _name;
                            TreeNode _attvalue = new TreeNode();
                            _attvalue.Name = _name;
                            _attvalue.Text = _value;
                            _attvalue.ForeColor = Color.Purple;
                            tnode.Nodes.Add(_attvalue);
                            aux.Nodes.Add(tnode);
                        }
                    }   
                }
            }
        }
