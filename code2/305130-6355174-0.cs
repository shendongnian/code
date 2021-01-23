	class Program
	{		
		static void Main(string[] args)
		{
			bool[] responses = new bool[] { true, false, true };
			
			Person people = new Person();
			people.PersonDetails.Add(new PersonDetail() { Correct = true });
			people.PersonDetails.Add(new PersonDetail() { Correct = false });
			people.PersonDetails.Add(new PersonDetail() { Correct = true });
			bool equal = responses.SequenceEqual(people.PersonDetails.Select(P=> P.Correct));
			Console.WriteLine (equal);
		}
	}
	public class Person
	{
		public List<PersonDetail> PersonDetails = new List<PersonDetail>();
	}
	public class PersonDetail
	{
		public bool Correct;
	}
