    public class Person
    {
       public static void InputPerson(Person p)
       {
          // Do the input logic here
       }
    }
    
    public class User
    {
        public Person Person { get; private set; }
    
        public static void InputUser(User u)
        {
            if (u.Person == null)
                u.Person = new Person;
            Person.InputPerson(u.Person);
            Console.WriteLine("Telephone:");
            u.Telephone = Console.ReadLine();
        }
    }
