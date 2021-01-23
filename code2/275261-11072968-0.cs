                        TreeNode rootNode = new TreeNode("Root Node");
                        treeViewTarget.Nodes.Add(rootNode);
                        foreach (TreeNode node in treeViewSource.Nodes)
                        {
                            rootNode.Nodes.Add((TreeNode)node.Clone());
                        }
                        rootNode.Expand();
