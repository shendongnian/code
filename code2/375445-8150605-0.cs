    private SomeType CheckIfConditionOfNestedItems(IEnumerable enumerable)
    {
        foreach (var thing in enumerable )
        {
            foreach (...)
            {
                //Some code
        
                if (statement)
                {
                    return result;
                }
            }
        }
    }
