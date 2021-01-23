    private bool TestAll()
    {
        var passed = true;
        foreach (var item in Items)
        {
            if ( ! Test(item))
            {
                passed = false;
            }
        }
        return passed && Items.Count != 0;
    }
