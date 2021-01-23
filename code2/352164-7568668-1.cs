    private void abort_Click(object sender, EventArgs e)
    {
    	if (abortingItem != null)
    	{
    		for (int u = 0; u < myURLslist.SelectedIndices.Count; u++)
    		{
    			//true means abort this item
    			abortingItem[myURLslist.SelectedIndices[u]] = true;
    		}
    	}
    }
