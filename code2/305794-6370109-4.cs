    public static IEnumerable<SomeType> ChangeSpecialCharacters(
        this IEnumerable<SomeType> items)
    {
        foreach(var item in items)
        {
            item.Name = item.Name.ChangeSpecialCharacters();
            item.Foo = item.Foo.ChangeSpecialCharacters();
            ...
            item.Bar = item.Bar.ChangeSpecialCharacters();
            yield return item;
        }
    }
