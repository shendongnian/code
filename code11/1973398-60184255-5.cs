cs
var str = "A;B;;;;C";
var parts = str.Split(';').Select(p => string.IsNullOrEmpty(p) ? " " : p);
var result = string.Join(";", parts);
The output will be the following `A;B; ; ; ;C`
Benchmark result in comparison with OP code and `Regex` solution: 
[![enter image description here][1]][1]
What is the clear and more elegant is up to you.
Benchmark code for the reference
cs
[SimpleJob]
public class Benchmark
{
	string input= "A;B;;;;C";
	[Benchmark]
	public string SplitJoinTest()
	{
		var parts = input.Split(';').Select(p => string.IsNullOrEmpty(p) ? " " : p);
		return string.Join(";", parts);
	}
	[Benchmark]
	public string DoubleReplaceTest()
	{
		return input.Replace(";;", "; ;").Replace(";;", "; ;");
	}
	[Benchmark]
	public string RegexTest()
	{
		return Regex.Replace(input, ";(?=;)", "; ");
	}
}
  [1]: https://i.stack.imgur.com/z3pNb.png
