    interface IFullNamed
	{
		string GetFullName();
	}
	public abstract class Person : IFullNamed
	{
		public virtual string Name { set; get; }
		public virtual string FamilyName { set; get; }
		public virtual string Patronymic { set; get; }
		string IFullNamed.GetFullName()
		{
			return $"{FamilyName} {Name} {Patronymic}";
		}
	}
	public class Person1 : Person
	{
		[DisplayName("First Name")]
		public override string Name { set; get; }
		[DisplayName("SurName")]
		public override string FamilyName { set; get; }
	}
	public class Person2 : Person
	{
		[DisplayName("PersonName")]
		public override string Name { set; get; }
		[DisplayName("Surname")]
		public override string FamilyName { set; get; }
		[DisplayName("Patr")]
		public override string Patronymic { set; get; }
	}
	public class Person3 : Person
	{
		[DisplayName("PersonName")]
		public override string Name { set; get; }
		[DisplayName("Surname")]
		public override string FamilyName { set; get; }
		[DisplayName("Patr")]
		public override string Patronymic { set; get; }
	}
