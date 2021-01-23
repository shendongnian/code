    public class Person { public int Age { get; set; } }
    ...
    static void Main(string[] args)
    {
        var setter = CreateSetter<Person, int>(p => p.Age);
        var person = new Person();
        setter(person, 25);
        Console.WriteLine(person.Age); // 25       
    }
