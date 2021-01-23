    public class X
    {
		public X()
		{
            if (this.GetType() == typeof(X))
            {
                Console.WriteLine("I'm X");
            }
		}
		public class Y : X
		{
            public Y()
            {
                Console.WriteLine("I'm Y");
            }
		}
		class Program
		{
            static void Main(string[] args)
            {
                Y y = new Y();
            }
		}
    }
