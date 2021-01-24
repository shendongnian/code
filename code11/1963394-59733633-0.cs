    public enum TreeVisitorResult {
        SkipNode,
        Continue
    }
    // the following two methods inside Tree<T>:
    public void VisitNodes(Func<TreeNode<T>, int, TreeVisitorResult> visitor) {
        VisitNodes(0, this.root, visitor);
    }
    private void VisitNodes(int depth, TreeNode<T> node,
        Func<TreeNode<T>, int, TreeVisitorResult> visitor) {
    
        if (node == null) {
            return;
        }
    
        var shouldSkip = visitor(node, depth);
        if (shouldSkip == TreeVisitorResult.SkipNode) {
            return;
        }
        
        TreeNode<T> child = null;
        for (int i = 0; i < node.ChildrenCount; i++) {
            child = node.GetChild(i);
            VisitNodes(depth + 1, child, visitor);
        }
    }
