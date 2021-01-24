    public IEnumerable<ItemInfo>  SomeMethod()
    {
        return new List<object>().
            .ConcatSelect<GeneralItem>(itemBase)
            .ConcatSelect<FirstTypeItem>(itemBase)
            .ConcatSelect<SecondTypeItem>(itemBase)
            .ConcatSelect<ThirdTypeItem>(itemBase)
            .Cast(ItemInfo);
    }
