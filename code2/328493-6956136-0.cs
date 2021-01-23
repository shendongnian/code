    public static bool SatisfiesCondition(IEnumerable<MyClass> items)
    {
        bool allEmptyString = items.All(item => item.MyOtherMember == "");
        if (allEmptyString)
        {
            return true;
        }
        // Okay, move onto the next condition...
        return !items.Select(item => item.MyMember)
                     .Distinct()
                     .Skip(1)
                     .Any();
    }
