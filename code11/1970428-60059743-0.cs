csharp
public class Seller 
{
	public string Name { get; set; }
	public int Id { get; set; }
	public string City { get; set; }
	public int Apples { get; set; }
}
class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Hi and Welcome to The Garden!");
		Console.WriteLine("How many sellers would u like to assign?");
		int Assign = int.Parse(Console.ReadLine());
		Seller[] NewSeller = new Seller[Assign];
		for (int i = 0; i < Assign; i++)
		{
			NewSeller[i] = new Seller();
			Console.WriteLine("______________________________");
			Console.Write($"Enter name for seller {i}: ");
			NewSeller[i].Name = Console.ReadLine();
			Console.Write($"Enter id for seller {i}: ");
			NewSeller[i].Id = int.Parse(Console.ReadLine());
			Console.Write($"Enter city for seller {i}: ");
			NewSeller[i].City = Console.ReadLine();
			Console.Write($"Enter apples sold for seller {i}: ");
			NewSeller[i].Apples = int.Parse(Console.ReadLine());
		}
		//default sorting is ascending, so low to high. use OrderByDescending when you need high to low
		Seller[] sortedList = NewSeller.OrderBy(s => s.Apples).ToArray();
		for (int i = 0; i < sortedList.Length; i++)
		{
			Seller currentSeller = sortedList[i];
			Console.WriteLine("__________________________________________________________");
			Console.WriteLine($"|   Seller {i} |");
			Console.WriteLine("|--------------");
			Console.WriteLine($"| Name: {currentSeller.Name}");
			Console.WriteLine($"| ID: {currentSeller.Id}");
			Console.WriteLine($"| City: {currentSeller.City}");
			Console.WriteLine($"| Apples sold: {currentSeller.Apples}");
			Console.WriteLine("__________________________________________________________");
		}
	}
}
