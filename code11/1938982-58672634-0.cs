public static implicit operator MultiDictionary<TKey, TValue>(Dictionary<TKey, HashSet<TValue>> d)
{
    return new MultiDictionary<TKey, TValue>(d);
}
public static implicit operator Dictionary<TKey, HashSet<TValue>> (MultiDictionary<TKey, TValue> md)
{
    return md.m_dictionaryOfHashSets;
}
Unlike languages such as C++ where you can do nasty things relying on the fact that the memory layout of two classes are identical, C# does not permit this. 
What value does your MultiDictionary class add over the Dictionary of HashSets anyhow? Could you perhaps provide this functionality with extension methods instead?
