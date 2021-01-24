void Main()
{
	var people = new List<Person>();
	
	var personOne = new Person{ FirstName = "jeff", LastName = "my name is", BirthDate = DateTime.Today};
	people.Add(personOne);
	Console.WriteLine(AddPerson(personOne, people, GroupCriteria.Birthday));
	Console.WriteLine(AddPerson(personOne, people, GroupCriteria.BirthdayFirstName));
	Console.WriteLine(AddPerson(personOne, people, GroupCriteria.BirthdayFirstNameLastName));
	Console.WriteLine(AddPerson(personOne, people, GroupCriteria.BirthdayLastName));
	
	var personTwo = new Person{ FirstName = "not jeff", LastName = "my name is", BirthDate = DateTime.Today};
	people.Add(personTwo);
	Console.WriteLine(AddPerson(personTwo, people, GroupCriteria.Birthday));
	Console.WriteLine(AddPerson(personTwo, people, GroupCriteria.BirthdayFirstName));
	Console.WriteLine(AddPerson(personTwo, people, GroupCriteria.BirthdayFirstNameLastName));
	Console.WriteLine(AddPerson(personTwo, people, GroupCriteria.BirthdayLastName));
}
int AddPerson(Person newPerson, List<Person> people, GroupCriteria crit)
{
	Func<Person, bool> countFunc = p => p.BirthDate == newPerson.BirthDate; ;
	
	switch(crit)
	{
		case GroupCriteria.Birthday:
			countFunc = p => p.BirthDate == newPerson.BirthDate;
			break;
		case GroupCriteria.BirthdayFirstName:
			countFunc = p => p.BirthDate == newPerson.BirthDate && p.FirstName == newPerson.FirstName;
			break;
		case GroupCriteria.BirthdayLastName:
			countFunc = p => p.BirthDate == newPerson.BirthDate && p.LastName == newPerson.LastName;
			break;
		case GroupCriteria.BirthdayFirstNameLastName:
			countFunc = p => p.BirthDate == newPerson.BirthDate && p.FirstName == newPerson.FirstName && p.LastName == newPerson.LastName;
			break;
	}
	
	var index = people.Count(countFunc);
		
	if(index == 0)
		return people.Count + 1;
	
	return index;
}
public class Person
{
	public string FirstName {get; set;}
	public string LastName {get; set;}
	public DateTime BirthDate {get;set;}
}
public enum GroupCriteria
{
	Birthday,
	BirthdayFirstName,
	BirthdayLastName,
	BirthdayFirstNameLastName
}
It seems like a silly exercise. that doesn't have a ton to do with linq.  Would love to see someone smarter than me comes up with.     
