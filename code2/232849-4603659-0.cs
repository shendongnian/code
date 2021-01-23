    var h1 = new Holder{ name = "name1", overView = new List<string>{ "Overview1", "Overview2" } };
    var h2 = new Holder{ name = "name2", overView = new List<string>{ "Overview1" } };
    var h3 = new Holder{ name = "name3", overView = new List<string>{ "Overview1" } };
    var h4 = new Holder{ name = "name4", overView = new List<string>{ "Overview2" } };
    
    List<Holder> list = new List<Holder> { h1, h2, h3, h4 };
    
    treeViewList.Nodes.Clear();
    
    for (int i = 0; i < list.Count; i++)
    {
        for (int j = 0; j < list[i].overView.Count; j++)
        {
            string overviewName = list[i].overView[j];
            //adds the overView name if doesn't exist yet
            TreeNode parent;
            if (!treeViewList.Nodes.ContainsKey(overviewName))
                parent = treeViewList.Nodes.Add(overviewName,overviewName);
            else
                parent = treeViewList.Nodes[overviewName];
    
            // adds the name under the overView
            parent.Nodes.Add(list[i].name);
        }
    }
    
    treeViewList.ExpandAll();
