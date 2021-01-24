using System.Linq;
(...)
public class ListObject
	{
		public string name {get;} // Made into properties and public
(...)
       List<ListObject> list = new List<ListObject>();
       list.Add(new ListObject("ran", new string[] { }, "Value"));
       list.Add(new ListObject("far", new string[] {"thest"}, "Value"));
       list.Add(new ListObject("the", new string[] {"ran"}, "Value"));
       list.Add(new ListObject("thest", new string[] {"ran", "the"}, "Value"));
            //What I want the order of the list to become
            /* ran
             * the
             * far
             * thest
             */
		
		foreach(var o in list) { Console.WriteLine(o.name);}
		
		var ordered = list
			.OrderBy(o => o.dependencies.Count()) // This is not needed, it's here just to show that you can chain OrderBy
			.ThenBy( o => string.Join(",",o.dependencies));
		Console.WriteLine(">>>Sorted");
		foreach(var o in ordered) { Console.WriteLine(o.name);}
Output:
ran
far
the
thest
>>>Sorted
ran
the
far
thest
----
Here is a version with the object references instead of strings
    public class ListObject
	{
		public string name { get; }
		public ListObject[] dependencies{get;}
		private object value;
		public ListObject(string name, ListObject[] dependencies, object value)
		{
			this.name = name;
			this.dependencies = dependencies;
			this.value = value;
		}
	}
	public static void Main(string[] args)
	{
		var ran = new ListObject("ran", new ListObject[0], "Value");
		var the = new ListObject("the", new[]{ran}, "Value");
		var thest = new ListObject("thest", new[]{ran, the}, "Value");
		var far = new ListObject("far", new[]{thest}, "Value");
		List<ListObject> list = new List<ListObject>(){ran, the, thest, far};
		//What I want the order of the list to become
		/* ran
             * the
             * far
             * thest
             */
		foreach (var o in list)
		{
			Console.WriteLine(o.name);
		}
		var ordered = list
              .OrderBy(o => o.dependencies.Count()) // This is not needed, it's here just to show that you can chain OrderBy
              .ThenBy(o => string.Join(",", o.dependencies.Select(d => d.name)));
		Console.WriteLine(">>>Sorted");
		foreach (var o in ordered)
		{
			Console.WriteLine(o.name);
		}
	}
