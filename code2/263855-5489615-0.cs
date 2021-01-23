    private void fillTree() { 
      string[] drives = Environment.GetLogicalDrives();
      foreach(string dr in drives) {
        TreeNode node = new TreeNode(dr);
        node.Tag = dr;
        node.ImageIndex = 0; // drive icon
        node.Tag = dr;
        treeView1.Nodes.Add(node);
        node.Nodes.Add(new TreeNode("?"));
      }
      treeView1.BeforeExpand += new TreeViewCancelEventHandler(treeView1_BeforeExpand);
    }
    
    void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
      if((e.Node.Nodes.Count == 1) && (e.Node.Nodes[0].Text=="?")) {
        RecursiveDirWalk(e.Node);
      }
    }
    
    private TreeNode RecursiveDirWalk(TreeNode node) {
      string path = (string)node.Tag;
      node.Nodes.Clear();
      string[] dirs = System.IO.Directory.GetDirectories(path);
      for(int t = 0; t < dirs.Length; t++) {
        TreeNode n = new TreeNode(dirs[t].Substring(dirs[t].LastIndexOf('\\')+1));
        n.ImageIndex = 1; // dir icon
        n.Tag = dirs[t];
        node.Nodes.Add(n);
        n.Nodes.Add(new TreeNode("?"));
      }
    
      // Optional if you want files as well:
      string[] files = System.IO.Directory.GetFiles(path);
      for(int t = 0; t < files.Length; t++) {
        TreeNode tn = new TreeNode(System.IO.Path.GetFileName(files[t]));
        tn.Tag = files[t];
        tn.ImageIndex = 2; // file icon
        node.Nodes.Add(tn);
      } // end of optional file part
    
      return node;
    }
