cs
public static class Ext
{
	public static string GetFullName(this Person1 person)
	{
		return $"{person.FamilyName} {person.Name} {person.Patronymic}";
	}
	public static string GetFullName(this Person2 person)
	{
		return $"{person.SurName} {person.FirstName} {person.Patronymic}";
	}
}
Since `string` in C# is immutable, it's better to use string interpolation or `string.Format()` rather then concatenate them (to avoid an additional copies of strings).
But in terms of basic architecture principles make sense to create a base abstract class or interface to encapsulate the fields, identifying a `Person` entity 
