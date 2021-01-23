    public int RandomPos(int max)
    {
        // compile the list of numbers we need to disqualify
        List<int> disqualified = numberList.Split(new[]{',',' '},StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToList();
            
        // Nothing to check against, save the CPU cycles
        if (disqualified.Count == 0)
            return (new Random(DateTime.Now.Millisecond)).Next(max) + 1;
        // make a list of everything that's possible for a choice
        List<int> valid = Enumerable.Range(0, max).Where(r => !disqualified.Contains(r)).ToList();
        // return either a valid result, or -1 if there are no valid results
        return (valid.Count == 0 ? -1 : valid[(new Random(DateTime.Now.Millisecond)).Next() % valid.Count]);
    }
