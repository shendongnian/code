    public IEnumerable<ItemInfo>  SomeMethod()
    {
        return itemBase.MatchType<GeneralItem>()
            .Concat(itemBase.MatchType<FirstTypeItem>())
            .Concat(itemBase.MatchType<SecondTypeItem>())
            .Concat(itemBase.MatchType<ThirdTypeItem>());
    }
