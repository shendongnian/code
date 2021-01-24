    public class Person<T>
    {
        public int Id { get; set; }            
    }
    public class Student : Person<Greeting>
    {   }
    public class StudentWarmGreeting : Person<WarmGreeting>
    {   }        
    public class Greeting 
    {
        public void SayHello()
        {
            Console.WriteLine("Hello, it is Greeting!:)");
        }
    }
    public class WarmGreeting
    {
        public void SayHello()
        {
            Console.WriteLine("Hello, it is WarmGreeting!:)");
        }
    }
