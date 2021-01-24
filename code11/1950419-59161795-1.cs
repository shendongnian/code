cs
using System.Linq;
class Program {
	static void Main(string[] args) {
		(int first, IEnumerable<int> remainder) = GetFirstAndRemainder(Enumerable.Range(1, 5));
		// first = 1
		// remainder yields (2, 3, 4, 5)
	}
	// Returns the first item and the remainders as an IEnumerable
	static (T, IEnumerable<T>) GetFirstAndRemainder<T>(IEnumerable<T> sequence) {
		var enumerator = sequence.GetEnumerator();
		enumerator.MoveNext();
		return (enumerator.Current, enumerator.AsEnumerable());
	}
}
You also need to convert from an `IEnumerator` to an `IEnumerable` which I did with an extension method:
cs
static class Extensions {
	public static IEnumerable<T> AsEnumerable<T>(this IEnumerator<T> enumerator) {
		while (enumerator.MoveNext()) {
			yield return enumerator.Current;
		}
	}
}
Note that due to your requirements, iterating once over the `remainder` will exhaust it even though it has the type `IEnumerable<T>`.
