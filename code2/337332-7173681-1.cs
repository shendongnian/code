    var members = new[] 
                {
                    new { MemberName = "Member 1", MemberId = 1 },
                    new { MemberName = "Member 2", MemberId = 2 }
                };
    var products = new[] 
                {
                    new { ProductName = "Product 1", ProductId = 1 },
                    new { ProductName = "Product 2", ProductId = 2 }
                };
    TreeNode membersNode = new TreeNode("Members", members.Select(m => new TreeNode(m.MemberName)).ToArray());
    TreeNode productsNode = new TreeNode("Products", products.Select(p => new TreeNode(p.ProductName)).ToArray());
    treeView1.Nodes.Add(membersNode);
    treeView1.Nodes.Add(productsNode);
