 c#
IEnumerator IEnumerable.GetEnumerator()
{
    return internDic.GetEnumerator();
}
public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
{
    return internDic.GetEnumerator();
}
Note also that it is common to just proxy the explicit implementation to the `public` one to avoid maintenance errors, i.e.
 c#
IEnumerator IEnumerable.GetEnumerator()
    => GetEnumerator();
public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    => internDic.GetEnumerator();
You could even expose the custom dictionary enumerator if you want to optimize for that:
 c#
IEnumerator IEnumerable.GetEnumerator()
    => GetEnumerator();
IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator()
    => GetEnumerator();
public Dictionary<string, string>.Enumerator GetEnumerator()
    => internDic.GetEnumerator();
