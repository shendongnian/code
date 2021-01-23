    Departments.Join(
    		Departments,
    		x => x.IDParentDepartment,
    		x => x.Name,
    		(o,i) => new { Child = o, Parent = i }
    	).GroupBy(x => x.Parent)
    	.Map(x => {
    			var node = new TreeNode(x.Key.Name);
    			x.Map(y => node.Nodes.Add(y.Child.Name));
    			treeView1.Nodes.Add(node);
    		}
    	)
