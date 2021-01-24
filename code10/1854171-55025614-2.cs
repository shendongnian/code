var intArray = new int[5];
var dictionary = new Dictionary<int, List<int>>();
for (int i = 0; i < intArray.Length; i++)
{
    var num = intArray[i];
    if (!dictionary.ContainsKey(num))
     {
        dictionary.Add(num, new List<int>());
     }
     dictionary[num].Add(i);
}
var max = dictionary.Keys.Max();
return dictionary[max];
This has less overall operations but is a bit more terse.
