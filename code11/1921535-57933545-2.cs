...
        static void Main(string[] args) {
            foreach (var arg in args) {
                Console.WriteLine(arg);
            }
        }
...
[![enter image description here][1]][1]
If needed, you could go further than this by stripping out logic in `ICSharpCode.Decompiler.IL.Transforms.*` and `ICSharpCode.Decompiler.CSharp.StatementBuilder`; Perhaps open an issue asking, whether a PR for your changes would be appreciated, as most of these "rawness" settings have been added relatively recently.
---
### A better example with enumerators
A laconic snippet of code
var numbers = new List<int> { 0, 1, 2 };
foreach (var num in numbers) Console.WriteLine(num);
compiles to 
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
(as seen with all transformation settings disabled)
---
### Further on for-loops:
As far as compilation goes, `for (a; b; c) d` is the same as `a; while (b) { d; c; }` (save for placement of continue-label), so decompilers will take liberty with deciding what kind of loop it might have been based on context similarity between init-statement, condition, and post-statement, so you might even write code by hand
var a = 0;
while (a < args.Length) {
    Console.WriteLine(args[a]);
    a++;
}
that will be detected as a for-loop (for there is no telling in IL)
for (int a = 0; a < args.Length; a++)
{
	System.Console.WriteLine(args[a]);
}
  [1]: https://i.stack.imgur.com/zATff.png
