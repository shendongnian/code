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
			.OrderBy(o => o.dependencies.Count())
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
