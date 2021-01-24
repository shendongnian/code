public static void aktar(string [] dizi)
{
  dizi = new string[5];
}
You can use `ref` as `steve-friedl` suggested or return the new array:
public static string[] aktar(string [] dizi)
{
  return new string[5];
}
(...)
dizi = aktar(dizi); 
Both approaches don't make a lot sense though as you loose the original data.
# B. Switch to `List<string>`
`List<T>` is ideal for storing data when the number of items may change.
public static void aktar(List<string> dizi)
{
  dizi.Add("x");
  dizi.Add("y");
}
static void Main(string [] args)
{
  var dizi = new List<string>{"a","b","c"};
  Console.WriteLine(dizi.Count);
  aktar(dizi);
  Console.WriteLine(dizi.Count);
  ...
## `List` test
### Code
public static void aktar(List<string> dizi)
{
  dizi.Add("x");
  dizi.Add("y");
}
static void Main(string [] args)
{
  var dizi = new List<string>{"a","b","c"};
  Console.WriteLine(dizi.Count);
  Console.WriteLine(string.Join(",", dizi));
  aktar(dizi);
  Console.WriteLine(dizi.Count);
  Console.WriteLine(string.Join(",", dizi));
}
### Output
3
a,b,c
5
a,b,c,x,y
