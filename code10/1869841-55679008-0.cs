    class Program
    {
        static void Main(string[] args)
        {
            var bar = new Bar("Jane Doe", 25);
            Console.WriteLine(bar.Speak());
            Console.Read();
        }
    }
    public class Foo
    {
        public string Name { get; set; }
        public Foo(string name)
        {
            Name = name;
        }
        public virtual string Speak() => $"My Name is {Name}";
    }
    public class Bar: Foo
    {
        public int Age { get; set; }
        public Bar(string name, int age) : base(name)
        {
            Age = age;
        }
        public override string Speak()
        {
            return $"{base.Speak()} and my age is {Age}";
        }
    }
