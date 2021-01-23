    public class Person 
    {
        public Name { get; set; }
        public void Greet()
        {
          Console.WriteLine("Hello");
        }
    }
    
    public class Child : Person
    {
       public Nickname { get; set;}
    }
