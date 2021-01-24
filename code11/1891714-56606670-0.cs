	public class Animal 
	{
		public virtual void Eat()
		{
		   Console.WriteLine( "A" ); 
		}
	}
	public class Pet : Animal
	{
		public override void Eat()
		{
			base.Eat();
			Console.WriteLine( "B" );
		}
	}
	public class Dog : Pet 
	{
		public override void Eat()
		{
			base.Eat();
			Console.WriteLine( "C" );
		}
	}
