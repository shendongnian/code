C#
public Dictionary<string, IEnumerable<string>> ConvertDictionary(Dictionary<string, string> data)
{
     return data.ToDictionary(x => x.Key, y => new List<string> { y.Value } as IEnumerable<string>);
}
