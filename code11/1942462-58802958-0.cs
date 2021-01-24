    public IEnumerable<ItemInfo>  SomeMethod()
    {
        return itemBase.OfType<GeneralItem>()
            .Concat(itemBase.OfType<FirstTypeItem>())
            .Concat(itemBase.OfType<SecondTypeItem>())
            .Concat(itemBase.OfType<ThirdTypeItem>());
    }
