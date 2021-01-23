        private static string PLACEHOLDER = "...";
        private void ListDrives()
        {
            string[] drives = Environment.GetLogicalDrives();
            foreach (string drive in drives)
            {
                if (Directory.Exists(drive))
                {
                    TreeNode node = new TreeNode(drive);
                    node.Tag = drive;
                    this.treeViewFolders.Nodes.Add(node);
                    node.Nodes.Add(new TreeNode(PLACEHOLDER));
                }
            }
            this.treeViewFolders.BeforeExpand += new TreeViewCancelEventHandler(treeView_BeforeExpand);
        }
        void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == PLACEHOLDER)
                {
                    e.Node.Nodes.Clear();
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());
                    foreach (string dir in dirs)
                    {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        TreeNode node = new TreeNode(di.Name);
                        node.Tag = dir;
                        try
                        {
                            if (di.GetDirectories().GetLength(0) > 0)
                                node.Nodes.Add(null, PLACEHOLDER);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            // TODO: update node images
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "ExplorerForm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            e.Node.Nodes.Add(node);
                        }
                    }
                }
            }
        }
