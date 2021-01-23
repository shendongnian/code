    IEnumerable<int> TestCases2()
    {
        foreach (var item in Enumerable.Range(0,10))
        {
            switch(item)
            {
                case 2:
                case 5:
                    throw new ApplicationException("This bit failed");
                default:
                    yield return item;
                    break;
            }
        }
    }
