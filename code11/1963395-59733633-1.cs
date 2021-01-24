    tree.VisitNodes((treeNode, depth) => { // <- this lambda will be called for every node
        if (treeNode.Value == "Unavailable") { // <- no need to ToString or cast here, since
                                               // we know that T is string here
            return TreeVisitorResult.SkipNode;
        } else {
            var spaces = new string(' ', depth * 3);
            Console.WriteLine(spaces + treeNode.Value);     
        }
    });
