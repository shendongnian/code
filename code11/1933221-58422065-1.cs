public class Dog
{
    public string Sound { get; set; } = "woof woof";
}
class Program
{
    static void Main(string[] args)
    {
        var dog = (Dog)Activator.CreateInstance(typeof(Dog));
        Console.WriteLine(dog.Sound);
        dog.Sound = "Homeowner".Substring(2, 4);
        Console.WriteLine(dog.Sound);
    }
}
Output
woof woof
meow
---- 
Version with strings
public class Dog
{
    public string Sound { get; set; } = "woof woof";
}
public class Dog
{
    public string Sound { get; set; } = "woof woof";
}
class Program
{
    static void Main(string[] args)
    {
        var dog2 = Activator.CreateInstance(Type.GetType("Dog"));
        Console.WriteLine(dog2.GetType().GetProperty("Sound").GetValue(dog2, null));
        dog2.GetType().GetProperty("Sound").SetValue(dog2, "Homeowner".Substring(2, 4));
        Console.WriteLine(((Dog)dog2).Sound);
    }
}
