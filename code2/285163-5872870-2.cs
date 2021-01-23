    private bool TestAllWithoutLinq()
    {
        if (Items.Count == 0) { // or something equivalent
            return false;
        }
        var allTestsPassed = true;
        foreach (var item in Items)
        {
            allTestsPassed = Test(item) && allTestsPassed;
        }
        return allTestsPassed;
    }
    private bool TestAllWithLinq()
    {
        return Items.Any() && Items.Count(Test) == Items.Count();
    }
