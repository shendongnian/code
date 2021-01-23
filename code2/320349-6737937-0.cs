    public abstract class Abstr
    {
        public void Describe()
        {
            //do something
        }
    }
    public class Concrete : Abstr
    {
       /*Some other methods and properties..*/ 
    }
    class Program
    {
        public void Main()
        {
            Abstr abstr = new Concrete();
            abstr.Describe();
            Console.ReadLine();
        }
    }
