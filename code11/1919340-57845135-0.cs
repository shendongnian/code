    public class Animal {
        protected string Kind, Says;
        protected Animal(string kind, string says) { Kind = kind; Says = says;
        }
        public string Talk(Animal impersonate, string stream) {
            return stream.Replace(impersonate.Kind, Kind).Replace(impersonate.Says, Says);
        }
    }
    public class Cow : Animal { public Cow() : base("cow", "moo") { } }
    public class Duck : Animal { public Duck() : base("duck", "quack") { } }
    public class Cat : Animal { public Cat() : base("cat", "meow") { } }
    public class Dog : Animal { public Dog() : base("dog", "aw") { } }
    public class Goat : Animal { public Goat() : base("goat", "mee") { } }
    public class Sheep : Animal { public Sheep() : base("sheep", "bee") { } }
    class Program {
        static void Sample2(string value)  {
            var cow = new Cow();
            foreach (var animal in new Animal[] {
                new Duck(),
                new Cat(),
                new Dog(),
                new Goat(),
                new Sheep()
            })
                Console.WriteLine("AFTER:  " + animal.Talk(cow, value));
        }
        static void Main(string[] args) {
            var value = "cow does something like moo";
            Console.WriteLine("BEFORE: " + value);
            Sample1(value);
            Sample2(value);
            Console.ReadLine();
        }
        static void Sample1(string value) {
            string modified = value.Replace("cow", "duck").Replace("moo", "quack");
            string modified1 = value.Replace("cow", "cat").Replace("moo", "meow");
            string modified2 = value.Replace("cow", "dog").Replace("moo", "aw");
            string modified3 = value.Replace("cow", "goat").Replace("moo", "mee");
            string modified4 = value.Replace("cow", "sheep").Replace("moo", "bee");
            Console.WriteLine("AFTER:  " + modified);
            Console.WriteLine("AFTER:  " + modified1);
            Console.WriteLine("AFTER:  " + modified2);
            Console.WriteLine("AFTER:  " + modified3);
            Console.WriteLine("AFTER:  " + modified4);
        }
    }
