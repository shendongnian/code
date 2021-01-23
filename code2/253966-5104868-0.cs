	[XmlRoot]
	[XmlType("Root")]
	public class MyRoot
	{
		// ...
	
		[XmlIgnore]
		public Dictionary<string, Tuple<int, ChildState>> Children { get; set; }
	
		[XmlElement("Child")]
		public MyChild[] ChildrenRaw
		{
			get
			{
				return Children.Select(c => new MyChild { Key = c.Key, Value = c.Value.Item1, State = c.Value.Item2 }).ToArray();
			}
	
			set
			{
				var result = new Dictionary<string, Tuple<int, ChildState>>(value.Length);
				foreach(var item in value)
				{
					result.Add(item.Key, new Tuple<int, ChildState>(item.Value, item.State));
				}
				Children = result;
			}
		}
	}
