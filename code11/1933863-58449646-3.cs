cs
T sum = default(T);
It also makes sense to use the generic type constraint for calculation, if you are using only numeric value types
cs
where S : struct, IComparable, IComparable<S>, IConvertible, IEquatable<S>, IFormattable
Also, you've passed `p => p.Weight` as `Func<T, T> getValue`, this is incorrect, you should declare additional generic parameter for return value for `Func`, currently you accept and return the same type
Finally, I make your snippet working, by adding an additional generic parameter and making `sum` as `dynamic` to avoid compile time errors
cs
public class Program
{
	static void Main(string[] args)
	{
		var listProducts = new List<Product<int>> {
			new Product<int> { Weight = 1},
			new Product<int> { Weight = 2},
			new Product<int> { Weight = 87}
		};
		var calc2 = new Calculator<Product<int>, int>();
		var averageWeight = calc2.Average(listProducts, p => p.Weight);
		Console.WriteLine($"Average weight is: {averageWeight}");
	}
}
public class Calculator<T, S> where S : struct, IComparable, IComparable<S>, IConvertible, IEquatable<S>, IFormattable
{
	public S Average(List<T> items, Func<T, S> getValue)
	{
		dynamic sum = default(S);
		foreach (var item in items)
		{
			var result= getValue(item);
			sum += result;
		}
		return (S)Convert.ChangeType(sum / items.Count, typeof(S));
	}
}
It prints
> Average weight is: 30
In your snippet `Product<int>` as generic type parameter for `Calculator` and `int` is generic type parameter for `Product<T>`, you can't use both of them as one parameter in `getValue` and return back from `Average`
