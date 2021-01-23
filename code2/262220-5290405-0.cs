private void PopulateTree(string dir, TreeNode node)
    {
        // get the information of the directory
        DirectoryInfo directory = new DirectoryInfo(dir);
        // loop through each subdirectory
        foreach (DirectoryInfo d in directory.GetDirectories("*", SearchOption.AllDirectories))
        {
           try
           {
                // create a new node
                TreeNode t = new TreeNode(d.Name);
                // populate the new node recursively
                PopulateTree(d.FullName, t);
                node.Nodes.Add(t); // add the node to the "master" node
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "Error Loading Directories", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        // lastly, loop through each file in the directory, and add these as nodes
        foreach (FileInfo f in directory.GetFiles())
        {
            // create a new node
            TreeNode t = new TreeNode(f.Name);
            // add it to the "master"
            node.Nodes.Add(t);
        }
    }
