    private bool TestAll()
    {
        if (Items.Count == 0)
        {
            return false;
        }
    
        foreach (var item in Items)
        {
            if ( ! Test(item))
            {
                return false;
            }
        }
    
        return true;
    }
