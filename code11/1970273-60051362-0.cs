public string ReturnString() { return "thisString"; }
If you are writing a method that creates the object and returns it to the calling method, then the return type would be the Person (unless you intend do something else). If you check the user input and decide not to create a Person, you can use `return null;`.
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Initial { get; set; }
}
public static Person CreatePerson()
{
    Person person = new Person();
    Console.Write("Please enter the first name: ", false);
    string fName = Console.ReadLine().ToUpper();
    if (string.IsNullOrEmpty(fName) || fName.ToLower().Equals("exit"))
        return null;
    person.FirstName = fName;
    Console.Write("Please enter the middle initial: ", false);
    string mInitial = Console.ReadLine().ToUpper();
    if (string.IsNullOrEmpty(mInitial) || mInitial.ToLower().Equals("exit"))
        return null;
    person.Initial = mInitial;
    Console.Write("Please enter the last name: ", false);
    string lName = Console.ReadLine().ToUpper();
    if (string.IsNullOrEmpty(lName) || lName.ToLower().Equals("exit"))
        return null;
    person.LastName = lName;
    return person;
}
And you can use this method in the Main,
public static void Main(string[] args) 
{
    Person person = CreatePerson();
    if (person == null) {
       Console.WriteLine("User Exited.");
    }
    else
    {
       // Do Something with person.
    }
}
