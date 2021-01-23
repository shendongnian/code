    ...
                AddString(@"C:\Windows\Notepad.exe");
                AddString(@"C:\Windows\TestFolder\test.exe");
                AddString(@"C:\Program Files");
                AddString(@"C:\Program Files\Microsoft");
                AddString(@"C:\test.exe");
    ...
    
            private void AddString(string name) {
                string[] names = name.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                TreeNode node = null;
                for(int i = 0; i < names.Length; i++) {
                    TreeNodeCollection nodes = node == null? treeView1.Nodes: node.Nodes;
                    node = FindNode(nodes, names[i]);
                    if(node == null)
                        node = nodes.Add(names[i]);
                }
            }
    
            private TreeNode FindNode(TreeNodeCollection nodes, string p) {
                for(int i = 0; i < nodes.Count; i++)
                    if(nodes[i].Text.ToLower(CultureInfo.CurrentCulture) == p.ToLower(CultureInfo.CurrentCulture))
                        return nodes[i];
                return null;
            }
