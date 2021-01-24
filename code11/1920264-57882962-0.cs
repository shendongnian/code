C#
void Main()
{
	var datas = new[] { new { id = 1 }, new {id=2}}.AsQueryable();
	var result = datas.OrderBy("id");
	Console.WriteLine(result); //1,2
}
// Define other methods and classes here
public static class MyExtension
{
	public static IEnumerable<T> OrderByProperty<T>(this IEnumerable<T> list,
  string property)
	{
		return list.AsQueryable().OrderBy(property);
	}
}
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/160h1.png
