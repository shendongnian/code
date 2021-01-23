    if (!treeViewCustomer.Nodes.ContainsKey(item.Customer)
    {
       treeViewCustomer.Nodes.Add(new TreeNode { 
         Name=item.Customer, 
         Text=item.Customer, 
         Value=item.Customer 
       });
    }
