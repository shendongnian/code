Added a extension method for IEnumberable&lt;T&gt;:
public static class IEnumberableExtensions
{
	public static bool AreEnumerablesEqual&lt;T&gt;(this IEnumerable&lt;T&gt; x, IEnumerable&lt;T&gt; y)
	{
		if (x.Count() != y.Count()) return false;
		bool equals = false;
		foreach (var a in x)
		{
			foreach (var b in y)
			{
				if (a.Equals(b))
				{
					equals = true;
					break;
				}
			}
			if (!equals)
			{
				return false;
			}
			equals = false;
		}
		return true;
	}
}
