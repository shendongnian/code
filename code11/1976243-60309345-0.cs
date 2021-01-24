csharp
object animal = new Animal { Doggy = new Dog { age = 10, name = "Good boy" }};
var members = animal.GetType().GetMembers();
foreach (PropertyInfo member in members.Where(x => x is PropertyInfo))
{
	if (member.PropertyType.Name == "Dog" || member.PropertyType.Name == "CatDog")
	{
		var propertyValue = member.GetValue(animal);
		var propertyType = propertyValue.GetType();
		var nameMember = propertyType.GetProperty("name");
		var ageMember = propertyType.GetProperty("age");
		var nameValue = nameMember.GetValue(propertyValue);
		var ageValue = ageMember.GetValue(propertyValue);
		Console.WriteLine($"Name: {nameValue}, Age: {ageValue}");
	}
}
Everything you need to do additionally is providing list of type names which you want to process (like "Dog" or "CatDog" here).
