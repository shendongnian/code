using System.Linq;
(...)
public class ListObject
	{
		public string name {get;} // Made public
(...)
var ordered = list.OrderBy(o => o.name);
foreach(var o in ordered) {
  Console.WriteLine(o.name);
}
