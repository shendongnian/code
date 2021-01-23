	public class abc
	{
		public string Name {get; set;}
	}
        //....
	var list = new List<abc>();
	list.Add(new abc() {Name="instance 1"});
	list.Add(new abc() {Name="instance 2"});
		
	foreach (var instance in list)
	{
		foreach (var property in instance.GetType().GetProperties())
		{
			Console.WriteLine(property.Name + "=" +
			                  property.GetValue(instance, null));
		}
	}
