    void Node_Selected(sender object, EventArgs args)
    {
        // find out which node was clicked
        Node node = object as Node;
        
        // get the data (model) node for this tree node
        INodeData data = node.Tag as INodeData;
        
        // create some info which will be passed to the manager.
        // you can pass information that might be useful,
        // or just simply pass the node data itself
        ISelectedNodeInfo info = new SelectedNodeInfo(data, some other stuff);
        
        // let the manager do the rest of the job
        _menuManager.UpdateState(info);
    }
