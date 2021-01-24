...
        static void Main(string[] args) {
            foreach (var arg in args) {
                Console.WriteLine(arg);
            }
        }
...
[![enter image description here][1]][1]
If needed, you could go further than this by stripping out logic in `ICSharpCode.Decompiler.IL.Transforms.*` and `ICSharpCode.Decompiler.CSharp.StatementBuilder`; Perhaps open an issue asking, whether a PR for your changes would be appreciated, as most of these "rawness" settings have been added relatively recently.
**Edit:** A slightly better example on foreach:
var numbers = new List<int> { 0, 1, 2 };
foreach (var num in numbers) {
    Console.WriteLine(num);
}
->
System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
list.Add(0);
list.Add(1);
list.Add(2);
System.Collections.Generic.List<int> numbers = list;
System.Collections.Generic.List<int>.Enumerator enumerator = numbers.GetEnumerator();
try
{
	while (enumerator.MoveNext())
	{
		int num = enumerator.Current;
		System.Console.WriteLine(num);
	}
}
finally
{
	((System.IDisposable)enumerator).Dispose();
}
  [1]: https://i.stack.imgur.com/zATff.png
