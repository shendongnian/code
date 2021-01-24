List<dynamic> list = new List<dynamic> { "blah", 15 };
var type = list[0].GetType();
Console.WriteLine(type); // prints out System.String
type = list[1].GetType();
Console.WriteLine(type); // prints out System.Int32
And if you want a list of all types, use Linq:
var types = list.Select(item => item.GetType());
// print out
foreach (var t in types) {
	Console.WriteLine(t);
}
