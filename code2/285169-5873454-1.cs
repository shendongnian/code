    private bool TestAll()
    {    
        foreach (var item in Items)
        {
            if ( ! Test(item))
            {
                return false;
            }
        }
        // true if _not_ empty; false otherwise    
        return Items.Count != 0;
    }
