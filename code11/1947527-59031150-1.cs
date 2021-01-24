cs
public class UpdatableClass
{
	public int Id { get; set; }
	public int IntValue { get; set; }
	public string StringValue { get; set; }
	public DateTime ModifiedDate { get; set; }
	private List<(Func<UpdatableClass, object> Get, Action<UpdatableClass, object> Set)> UpdatableFields =
		new List<(Func<UpdatableClass, object>, Action<UpdatableClass, object>)>
		{
			(c => c.IntValue, (c, v) => { c.IntValue = Convert.ToInt32(v); }),
			(c => c.StringValue, (c, v) => { c.StringValue = v.ToString(); })
		};
	public bool Update(UpdatableClass newValues)
	{
		bool isUpdated = false;
		foreach (var field in UpdatableFields)
		{
			object oldValue = field.Get(this);
			object newValue = field.Get(newValues);
			if (!newValue.Equals(oldValue))
			{
				field.Set(this, newValue);
				isUpdated = true;
			}
		}
		return isUpdated;
	}
}	
