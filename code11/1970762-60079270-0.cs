cs
public sealed class CompositeMap : ClassMap<Composite>
{
	public CompositeMap()
	{
		Map(m => m.a.ID);
		Map(m => m.b.Name);
	}
}
If you have a specific reason you need to use `References`, let me know and I can update the answer.
