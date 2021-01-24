`
public virtual Dictionary<string, string> SmallDict
{
    get
    {
        return BigDict.ToDictionary(x => x.Key, x => x.Value.ElemFromStruct);
    }
}
`
