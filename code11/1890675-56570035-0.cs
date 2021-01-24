class Information
{
	public string Id { get; set; }
	public string Name { get; set; }
	public string ParentId { get; set; }
	public List<Information> Children = new List<Information>();
}
The sample data:
var data = new List<string>
{
	"2,element1,1",
	"1,element,",
	"3,element2,2",
	"4,element23,1"
};
Logic for structuring the data:
//Create a dictionary of all items (for performance)
var dict = data
	.Select(s => s.Split(','))
	.Select(s => new Information
	{
		Id = s[0],
		Name = s[1],
		ParentId = s[2]
	})
	.ToDictionary(s => s.Id);
//Link the items by adding each item to the children list
foreach (var v in dict.Values)
{
	if (!string.IsNullOrWhiteSpace(v.ParentId))
	{
		dict[v.ParentId].Children.Add(v);
	}
}
Create a method that calls itself for printing recursively:
void PrintRecursive(Information i, int tabCount)
{
	//Print the item
	Console.WriteLine($"{new string('\t', tabCount)}{i.Id},{i.Name},{i.ParentId}");
	foreach (var child in i.Children.OrderBy(o => o.Id))
	{
		//Call the same method with increased tab
		PrintRecursive(child, tabCount + 1);
	}
}
Finally, call the print method for all parent items on the highest level:
//Print recursively
foreach(var item in dict.Values.Where(o => string.IsNullOrWhiteSpace(o.ParentId)))
{
	PrintRecursive(item, 0);
}
