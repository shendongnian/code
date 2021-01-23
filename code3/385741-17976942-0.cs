    Console.WriteLine("\n\n /* Lowest Common Ancestor */");
    int v1 = 4, v2 = 8;
    Node lca = LCA(Root, v1, v2);
    Console.WriteLine("LCA of {0} and {1} is: {2}", v1, v2, (lca != null ? lca.Data.ToString() : "No LCA Found"));
    public static Node LCA(Node root, int v1, int v2)
    {
            if (root == null)
                return null;
    
            if (root.Data > v1 && root.Data > v2)
                return LCA(root.Left, v1, v2);
            else if (root.Data < v1 && root.Data < v2)
                return LCA(root.Right, v1, v2);
            else
                return root;
    }
