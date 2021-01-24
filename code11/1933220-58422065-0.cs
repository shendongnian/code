class Program
{
    public class Dog
    {
        public string Sound { get; set; } = "woof woof";
    }
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
