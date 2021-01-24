C#
public class Program
{
	public static void Main()
	{
		var result = Method(1, 2).Select( (r,c) => new { r,c });
		Console.WriteLine(result);
	}
	static int[] Method(int r,int c) => new[] {r,c};
}
public static class LinqExtension
{
	public static T Select<T>(this int[] ints, Func<int,int, T> func) => func(ints[0],ints[1]);
}
[![enter image description here][1]][1]
or you can use Method with `params int[]` and `static class ` to make a select method
C#
public class Program
{
	public static void Main()
	{
		var value = Method(1, 2).Select((int[] arr) => new{r = arr[0],c = arr[1]});
		Console.WriteLine(value); //result : { r = 1, c = 2 }
	}
	public static int[] Method(params int[] ints)
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
  [1]: https://i.stack.imgur.com/9G5CI.png
