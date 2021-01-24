    private Tuple<string[], string[]> storeParametersInArrays(string[] notallowed, string[] allowed, CheckedListBox checkedListBox)
    {
    	int i = 0; // allowed objects
    	int j = 0; // not allowed objects
    	int k = 0; // item counter
    
    	foreach (object item in checkedListBox.Items)
    	{
    		if (!checkedListBox.CheckedItems.Contains(item))
    		{
    			notallowed[j++] = checkedListBox.Items[k].ToString();
    		}
    		else
    		{
    			allowed[i++] = checkedListBox.Items[k].ToString();
    		}
    		k++;
    	}
    	return Tuple.Create(allowed, notallowed);
    }
