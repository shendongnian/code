    public static IEnumerable<Node> GetAllNodes( Node root )
    {
        if( root == null )
        {
            yield break;
        }
    
        yield return root;
    
        if ( root.Nodes == null )
        {
            yield break;
        }
    
        foreach ( Node descendant in root.Nodes.SelectMany( GetAllNodes ) )
        {
            yield return descendant;
        }
    }
