    foreach (Type type in asm.GetTypes())
    {
        var tnode = new TreeNode(type.Name);
        foreach (MethodInfo method in type.GetMethods())
        {
            tnode.Nodes.Add(method.Name);
        }
        treeView1.Nodes.Add(tnode);
    }
