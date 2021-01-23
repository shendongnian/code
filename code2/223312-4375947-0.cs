    private Byte[] SerilizeQueryFilters()
        {
            BinaryFormatter bf = new BinaryFormatter();
            TreeNodeCollection tnc = treeView1.Nodes;
            List<TreeNode> list = new List<TreeNode>();
            list.Add(treeView1.Nodes[0]);
      
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, list);
                return ms.GetBuffer();
            }
        }
