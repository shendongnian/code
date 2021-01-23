    class Program
    {
        static void Main(string[] args)
        {
            LetMeChange original = new LetMeChange { Name = "Bob" };
            SomethingMoreComfortable casted = original;
            Console.WriteLine(casted.Name);
        }
    }
    public class LetMeChange
    {
        public static implicit operator SomethingMoreComfortable(LetMeChange original)
        {
            return new SomethingMoreComfortable() { Name = original.Name };
        }
        public string Name
        {
            get;
            set;
        }
    }
    public class SomethingMoreComfortable
    {
        public string Name
        {
            get;
            set;
        }
    }
