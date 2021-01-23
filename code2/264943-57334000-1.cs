    class Person
    {
        public string head;
        public string feet;
        // Downside: It has to be manually implemented for every class
        public Person Clone()
        {
            return new Person() { head = this.head, feet = this.feet };
        }
    }
    
    class Program
    {
        public static void Main(string[] args)
        {
            Person a = new Person() { head = "bigAF", feet = "smol" };
            Person b = a.Clone();
            b.head = "notEvenThatBigTBH";
            Console.WriteLine($"{a.head}, {a.feet}");
            Console.WriteLine($"{b.head}, {b.feet}");
        }
    }
