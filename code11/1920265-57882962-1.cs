C#
void Main()
{
	var datas = new[] { new { id = 3 }, new { id = 2 } };
	var result = datas.OrderByProperty("id");
	Console.WriteLine(result); //2,3
}
// Define other methods and classes here
public static class MyExtension
{
	public static IEnumerable<T> OrderByProperty<T>(this IEnumerable<T> list,string property)
	{
		return list.AsQueryable().OrderBy(property);
	}
}
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/WxcK5.png
