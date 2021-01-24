cs
// Here i am using one more constructor for initializing it with some values later on
public Employee(int number, string firstName, string lastName)
{
	EmpId = number;
	FirstName = firstName;
	LastName = lastName;
}
Also it makes sense to declare your fields as private, or use readonly properties instead
cs
public int EmpId { get; }
public string FirstName { get; }
public string LastName { get; }
Otherwise your `struct` is mutable. Also it contains a reference type values, like `string`. It's better to introduce an `Employee` class rather than struct
