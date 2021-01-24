C#
void Main()
{
	List<int> IntList = new List<int>() { 1, 2, 3, 4, 5 };
	List<string> StringList = new List<string>() { "a", "b", "c", "d", "e" };
	
	var expected = (from t1 in IntList
					join t2 in StringList on IntList.IndexOf(t1) equals StringList.IndexOf(t2)
					select new Table {a=t1,b=t2}
	).ToList();
	Console.WriteLine(expected);
}
public class Table
{
	public int a { get; set; }
	public string b { get; set; }
}
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/V8hKJ.png
