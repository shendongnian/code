       // Add a root TreeNode for each Customer object in the ArrayList.
       foreach(Customer customer2 in customerArray)
       {
          treeView1.Nodes.Add(new TreeNode(customer2.CustomerName));
    
          // Add a child treenode for each Order object in the current Customer object.
          foreach(Order order1 in customer2.CustomerOrders)
          {
             treeView1.Nodes[customerArray.IndexOf(customer2)].Nodes.Add(
               new TreeNode(customer2.CustomerName + "." + order1.OrderID));
          }
       }
