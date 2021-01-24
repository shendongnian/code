public class MinMaxPair<T>
{
	public MinMaxPair(T min, T max)
	{
		Min = min;
		Max = max;
	}
	
	public T Min;
	public T Max;
}
Then with that in place, the `.Aggregate()` call would simply be
nums.Aggregate(
	new List<MinMaxPair<int>>(),
	(sets, next) =>
	{
		if (!sets.Any() || next - sets.Last().Max > 1)
		{
			sets.Add(new MinMaxPair<int>(next, next));
		}
		else
		{
			var minMax = sets.Last();
			if (next < minMax.Min)
				minMax.Min = next;
			else
				minMax.Max = next;
		}
		return sets;
	});
