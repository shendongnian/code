    public class Program
    {
        public virtual void display()
        {
            Console.WriteLine("This is Function Overriding");
        }
        public virtual void rnreddy()
        {
            Console.WriteLine("This is Possible because of RN Reddy");
        }
        
        static void Main(string[] args)
        {
            Program dc = new Program();
            dc.display();
            dc.rnreddy();
            Console.ReadLine();
        }
    }
