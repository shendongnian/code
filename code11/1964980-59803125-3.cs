    public class Student : Person<Greeting>
    {
    }
    
    public class Person<T> where T : ISayHello
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Greeting : ISayHello
    {
        public void SayHello()
        {
            Console.WriteLine("Hello, it is me!:)");
        }
    }
    public interface ISayHello
    {
        void SayHello();
    }
