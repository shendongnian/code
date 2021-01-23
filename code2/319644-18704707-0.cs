    {
        //Uncomment this line below and inspect the 'nodes' variable if you need to inspect all of the nodes
    	//var nodes = this.MyTreeView.Nodes;
    
    	//Some call to get data for example
    	var dataCollection = GetSomeDataForTheTree()
    	
    	//Iterate through and create a new node for each row in the query results.
    	//Notice that the query results are stored in the table of the DataSet.
        foreach (MyClassWithData data in dataCollection)
        {
            //Create the new node using the values from the collection:
            TreeNode newNode = new TreeNode(data.LastName, system.ID)
                {
                    //Set the PopulateOnDemand property to false, because these are leaf nodes 
    				and do not need to be populated on subsequent calls.
                    PopulateOnDemand = false,
                    SelectAction = TreeNodeSelectAction.Select
                };
    
            //Add the new node to the ChildNodes collection of the parent node.                    
    		e.node.ChildNodes.Add(NewNode);
        }
    }
