    private bool TestAll()
    {
        foreach (var item in Items)
        {
            if(!(Test(item)))
            {
            	return false;
            }
        }
    return true;
    }
