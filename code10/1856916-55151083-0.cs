    private static TreeNode GetFirstMatch(TreeNodeCollection allNodes, 
        Func<TreeNode, bool> validator)
    {
        if (allNodes == null) return null;
        // Initialize a Queue with all the root nodes
        var nodeQueue = new Queue<TreeNode>(allNodes.OfType<TreeNode>());
        // Use a queue for a breadth-first search
        while (nodeQueue.Any())
        {
            // Remove the next item
            var current = nodeQueue.Dequeue();
            // Return it if it passes our validation
            if (validator.Invoke(current)) return current;
            // Add it's children to the end of the queue
            foreach (TreeNode child in current.Nodes)
            {
                nodeQueue.Enqueue(child);
            }
        }
        // If we didn't find any matches, return null
        return null;
    }
