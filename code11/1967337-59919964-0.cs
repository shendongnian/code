cs
// Here i am using one more constructor for initializing it with some values later on
public Employee(int number, string firsname, string lasname)
{
	EmpId = number;
	FirstName = firsname;
	LastName = lasname;
}
Also it makes sense to declare your fields as private, or use readonly properties instead
cs
public int EmpId { get; }
public string FirstName { get; }
public string LastName { get; }
