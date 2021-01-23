    IEnumerable<List<Item>> TestLists(List<Item> fullList)
    {
        List<Type> types = fullList.Select(i => i.GetType()).Distinct().ToList();
        List<Item> testList = new List<Item> { (Item)Activator.CreateInstance(types[0]) };
        yield return testList;
        bool finished = false;
        while (!finished)
        {
            bool incremented = false;
            int i = 0;
            while (i < types.Count && !incremented)
            {
                if (testList.Where(t => t.GetType() == types[i]).Count() <
                    fullList.Where(t => t.GetType() == types[i]).Count())
                {
                    testList.Add((Item)Activator.CreateInstance(types[i]));
                    incremented = true;
                }
                else
                {
                    testList = testList.Where(t => t.GetType() != types[i]).ToList();
                    i++;
                }
            }
            if (incremented)
            {
                yield return testList;
            }
            else
            {
                finished = true;
            }
        }
    }
