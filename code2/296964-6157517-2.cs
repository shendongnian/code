    public void TraverseNodes(Node parentNode)
    {
       //iterate through child nodes
       foreach(var node in parentNode)
       {
           //action
           //iterate though child's child nodes. 
           TraverseNodes(node);
       }
    }
