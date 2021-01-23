    private bool TestAll()
    {
        var allTestsPassed = true;
        foreach (var item in Items)
        {
            allTestsPassed = Test(item) && allTestsPassed;
        }
        return allTestsPassed;
    }
