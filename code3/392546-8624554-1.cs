    public void SearchAndAdd(string searchKey, string newValue)
     {
      TreeNode[] list = treeView1.Nodes.Find(searchKey, true);
      if (list.Length != 0)
       {
        list[0].Nodes.Add(newValue,newValue);
       }
     }
