    private void AddNode(NodeParent, Data)
    {
        Node oNode;
    
        //Check if this is the first node
        if (NodeParent ==null)
        {
             oNode = new Node(Data.Name);
        }
    
        //Step though each child item in the data
        foreach(DataItem in Data)
        {
            //Add the node
             this.AddNode(oNode, DataItem);
        }
    
        oNode.Nodes.Add(new Node(Data));
    }
