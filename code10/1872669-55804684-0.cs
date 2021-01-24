cs
var multiParamValues = new Dictionary<string, string[]>();
multiParamValues.Add("ParamA", new string[] { "1", "2" });
multiParamValues.Add("ParamB", new string[] { "55", "56" });
var numberOfParameters = multiParamValues.First().Value.Length;
for (var k = 0; k < numberOfParameters; k++)
{
    foreach (var item in multiParamValues)
    {
        Console.WriteLine("{0}, {1}", item.Key, item.Value[k]);
    }
}
Please note that the order of elements in Dictionary is NOT guaranteed by C# spec.
