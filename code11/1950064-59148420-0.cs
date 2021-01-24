public abstract class Buildable{}
class Road : Buildable{}
class House : Buildable{}
You can do the following
List<Buildable> buildables = new List<Buildable>();
buildables.Add(new House());
buildables.Add(new Road());
buildables.Add(new House());
	
foreach(var item in buildables)
{
	if(typeof(House) == item.GetType())
	{
		Console.WriteLine("House");
	}
	if (typeof(Road) == item.GetType())
	{
		Console.WriteLine("Road");
	}
}
Or in C# 8.0 you can do advanced pattern matching like the following:
abstract class Buildable { 
	public bool Damage;
}
class Road : Buildable { }
class House : Buildable { }
And pattern match with:
List<Buildable> buildables = new List<Buildable>();
buildables.Add(new House());
buildables.Add(new Road());
buildables.Add(new House{  Damage = true });
foreach (var item in buildables)
{
    switch (item)
	{
		case House damageHouse when damageHouse.Damage:
			Console.WriteLine("House Damaged");
			break;
		case House house:
			Console.WriteLine("House");
			break;
		case Road road:
			Console.WriteLine("Road");
			break;
		case Buildable _:
			Console.WriteLine("Default");
			break;
	}
			
}
