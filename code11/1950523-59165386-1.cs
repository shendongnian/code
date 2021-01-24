c#
static void Main(string[] args)
{
    var dict1 = new Dictionary<int, (int, int)>();
    dict1.Add(1, (1, 1));
    dict1.Add(2, (2, 2));
    dict1.Add(3, (3, 3));
    var dict2 = new Dictionary<int, (int, int)>();
    dict2.Add(4, (2, 2));
    dict2.Add(5, (3, 3));
    dict2.Add(6, (4, 4));
    var intersection = dict1.Intersect(dict2, new eq());
    foreach (var i in intersection)
        Console.WriteLine($"Key: {i.Key}, Value: {i.Value}");
    Console.ReadLine();
}
class eq : IEqualityComparer<KeyValuePair<int, (int, int)>>
{
    public bool Equals(KeyValuePair<int, (int, int)> x, KeyValuePair<int, (int, int)> y)
    {
        return x.Value == y.Value;
    }
    public int GetHashCode(KeyValuePair<int, (int, int)> obj)
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + obj.Value.Item1;
            hash = hash * 23 + obj.Value.Item2;
            return hash;
        }
    }
}
>Key: 2, Value: (2, 2)  
Key: 3, Value: (3, 3)
*Hash from [this answer](https://stackoverflow.com/a/263416/832052) from Jon Skeet*
