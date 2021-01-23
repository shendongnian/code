	public class Derived : Base
	{
		public Derived()
		{
			x = 7;
		}
	}
	public class Base
	{
		public int x;
		public int t;
		public void adjust()
		{
			t = x * 6;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Base a = new Derived();
			a.adjust();
			Console.WriteLine(string.Format("'Please, tell me the answer to life, the universe and everything!' 'Yeah, why not. Here you go: {0}", a.t));
		}
	}
