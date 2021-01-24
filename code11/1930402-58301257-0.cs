Dictionary<string, int> dictionary = new Dictionary<string, int>();
dictionary.Add("a", 1);
dictionary.Add("b", 2);
dictionary.Add("c", 34);
dictionary.Add("d", 35);
dictionary.Add("e", 105);
dictionary.Add("f", 106);
dictionary.Add("g", 140);
dictionary.Add("h", 141);
var items = from pair in dictionary
            orderby pair.Value ascending
            select pair;
var list_1_32 = items.Where(v => v.Value >= 1 && v.Value <= 32)
                .ToDictionary(k => k.Key, v => v.Value);
var list_33_64 = items.Where(v => v.Value >= 33 && v.Value <= 64)
                 .ToDictionary(k => k.Key, v => v.Value);
var list_101_132 = items.Where(v => v.Value >= 101 && v.Value <= 132)
                   .ToDictionary(k => k.Key, v => v.Value);
var list_133_164 = items.Where(v => v.Value >= 133 && v.Value <= 164)
                   .ToDictionary(k => k.Key, v => v.Value);
Action<Dictionary<string, int>> print = instance =>
{
  foreach ( var item in instance )
    Console.WriteLine($"{item.Key}: {item.Value}");
};
print(list_1_32);
Console.WriteLine();
print(list_33_64);
Console.WriteLine();
print(list_101_132);
Console.WriteLine();
print(list_133_164);
Output:
a: 1
b: 2
c: 34
d: 35
e: 105
f: 106
g: 140
h: 141
