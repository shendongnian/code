    private void fillTree() { // you allready had most of this
      string[] drives = Environment.GetLogicalDrives();
      foreach(string dr in drives) {
        TreeNode node = RecursiveDirWalk(dr);
        node.ImageIndex = 0; // drive icon
        node.Tag = dr;
        treeView1.Nodes.Add(node);
      }
    }
    // now add this
    private TreeNode RecursiveDirWalk(string path) {
      TreeNode node = new TreeNode(path.Substring(path.LastIndexOf('\\')));
      node.ImageIndex = 1; // dir icon
      node.Tag = path;
      string[] dirs = System.IO.Directory.GetDirectories(path);
      for(int t = 0; t < dirs.Length; t++) {
        node.Nodes.Add(RecursiveDirWalk(dirs[t]));
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
