class Logins
{
    public string Name { get; set; }
    public string Surname { get; set; }   
}
You could write code like:
    Console.Write("Enter your name: ");
    string name = Console.ReadLine();
    Console.Write("Enter your Surname: ");
    string surname = Console.ReadLine();
    Logins user1 = new Logins() { Name = name, Surname = surname };
    Console.WriteLine("Hello, {0} {1}.", user1.Name, user1.Surname);
