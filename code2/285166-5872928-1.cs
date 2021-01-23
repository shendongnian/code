    private bool TestAll()
    {
        foreach (var item in Items)
        {
            if(!(Test(item)) || Items.Count == 0)
            {
            	return false;
            }
        }
    return true;
    }
