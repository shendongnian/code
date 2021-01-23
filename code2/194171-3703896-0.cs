    public void CreateNewFolder()
    {
       var newNode = myTreeView.Nodes.Add("New Folder");
       newNode.BeginEdit();
    }
