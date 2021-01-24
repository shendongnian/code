C#
public class Program
{
	private void Main()
	{
		var value = Method(1, 2, 3).Select((int[] arr) => new{r = arr[0],c = arr[1]});
		Console.WriteLine(value); //result : { r = 1, c = 2 }
	}
	private int[] Method(params int[] ints)
	{
		return ints;
	}
}
public static class LinqExtension
{
	public static T Select<T>(this int[] ints,Func<int[],T> func){
		return func(ints);
	}	
}
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/GdQy3.png
