    public Control GetControlByClientId(string clientId)
    {
    	Queue<string> clientIds = new Queue<string>(clientId.Split(ClientIDSeparator));
    	Control root = this.Page;
    	string subControlId = null;
    	while (clientIds.Count > 0)
        {
    		if (subControlId == null)
            {
    			subControlId = clientIds.Dequeue();
    		}
            else
            {
    			subControlId += ClientIDSeparator + clientIds.Dequeue();
    		}
    		Control subControl = root.FindControl(subControlId);
    		if (subControl != null)
            {
    			root = subControl;
    			subControlId = null;
    		}
    	}
    	if (root.ClientID == clientId)
        {
    		return root;
    	}
        else
        {
    		throw new ArgumentOutOfRangeException();
    	}
    }
