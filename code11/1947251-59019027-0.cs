cs
List<string> list = new List<string>();
list.Add("001");
list.Add("002");
list.Add("003");
list.Add("004");
list.RemoveAll(s => s == "002");
Console.WriteLine(list.Count()); // 3
You can also achieve the same thing using LINQ operators:
cs
List<string> list = new List<string>();
list.Add("001");
list.Add("002");
list.Add("003");
list.Add("004");
list = list.Where(s => s != "002").ToList();
Console.WriteLine(list.Count());
More succinctly:
cs
List<string> list = new List<string>(new[] {
	"001",
	"002",
	"003",
	"004"
});
// or
//List<string> list = new[] {
//	"001",
//	"002",
//	"003",
//	"004"
//}.ToList();
Console.WriteLine(list.Count(s => s != "002")); // 3
