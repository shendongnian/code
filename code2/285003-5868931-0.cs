        public static void SaveTree(TreeView tree, string filename)
        {
              ArrayList al = new ArrayList();
              foreach (TreeNode tn in tree.Nodes)
              {
                  al.Add(tn);
              }
   
              using(Stream file = File.Open(filename, FileMode.Create))
              {
                  BinaryFormatter bf = new BinaryFormatter();
                  bf.Serialize(file, al);
              }
        }
        public static void LoadTree(TreeView tree, string filename)
        {
            using(Stream file = File.Open(filename, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                object obj = bf.Deserialize(file);
                ArrayList nodeList = obj as ArrayList;
   
                foreach (TreeNode node in nodeList)
                {
                   tree.Nodes.Add(node);
                }
            }
        }
