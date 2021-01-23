    class Person {
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString() {
            return string.Format("{0} {1}", Name, Age);
        }
    }
    class Program {
        static void Main(string[] args) {
            List<Person> list = new List<Person>
            {
                new Person { Name = "John", Age = 24 }, 
                new Person { Name = "Tom", Age = 35 },
                new Person { Name = "Mike", Age = 42 },
                new Person { Name = "Steve", Age = 51 }
            };
            var phil = new Person { Name = "Phil", Age = 45 };
            
            var findTwo = list.OrderBy(p => p.Age).Reverse().SkipWhile(p => p.Age > phil.Age).Take(1).Concat(list.OrderBy(p => p.Age).SkipWhile(p => p.Age < phil.Age).Take(1));
            foreach(var person in findTwo) {
                Console.WriteLine(person);
            }
            Console.WriteLine("DONE");
            Console.ReadLine();
        }
    }
