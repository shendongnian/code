    using System;
    
    namespace ConsoleApp25
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                var personDescriptor = new PersonDescriptor { IsGood = true };
    
                var resultPerson = personDescriptor.CreateInstance();
    
                Console.WriteLine(resultPerson.IsGood);
                Console.WriteLine(resultPerson.GetType().Name);
    
                Console.ReadLine();
            }
        }
    
        public class PersonDescriptor
        {
            public bool IsGood { get; set; }
    
            public Person CreateInstance()
            {
                if (IsGood)
                    return new GoodPerson(); //create new instance!
                return new BadPerson(); //create new instance!
            }
        }
    
        public abstract class Person
        {
            public abstract bool IsGood { get; }
        }
    
        public class GoodPerson : Person
        {
            public override bool IsGood { get; } = true;
        }
    
        public class BadPerson : Person
        {
            public override bool IsGood { get; } = false;
        }
    
    }
    
