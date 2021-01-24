class User
{
    public string Name { get; set; }
    public string Surname { get; set; }   
}
You could write code like:
    Console.Write("Enter your name: ");
    string name = Console.ReadLine();
    Console.Write("Enter your Surname: ");
    string surname = Console.ReadLine();
    User user1 = new User() { Name = name, Surname = surname };
    Console.WriteLine("Hello, {0} {1}.", user1.Name, user1.Surname);
----
Now, looking at that code above, it seems a little repetitive. We can wrap both the `Console.Write` and `Console.ReadLine` calls into a single method that takes in a `string` that represents the prompt for the user, and which returns a `string`, which is the user's input:
    private static string GetUserInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }
And now we can cut the lines of code needed to get user input from 4 to 2:
    string name = GetUserInput("Enter your name: ");
    string surname = GetUserInput("Enter your surname: ");
----
And, in fact, we can get really crazy and reduce the code to instantiate a new `User` class to one line, where we call our method and use it's return value when creating the object:
    static void Main(string[] args)
    {
        User user1 = new User 
        {
            Name = GetUserInput("Enter your name: "),
            Surname = GetUserInput("Enter your surname: ")
        };
        Console.WriteLine("Hello, {0} {1}.", user1.Name, user1.Surname);
        Console.ReadKey();
    }
