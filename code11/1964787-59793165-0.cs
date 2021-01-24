public static void Main()
{
	var Persons = new List<Person>();
	foreach (var prsn in Persons)
	{
		Console.WriteLine(prsn.ID);
		foreach (var sibling in prsn.GetDescendantSibilings())
		{
			Console.WriteLine(sibling.ID);
		}
	}
	Console.ReadLine();
}
public class Person
{
	public int ID { get; set; }
	public string Name { get; set; }
	public List<Person> Siblings { get; set; }
	public List<Person> GetDescendantSibilings()
	{
		var toReturn = new List<Person>(Siblings);
		foreach(var sib in Siblings)
		{
			toReturn.AddRange(sib.GetDescendantSibilings());
		}
		return toReturn;
	}
}
