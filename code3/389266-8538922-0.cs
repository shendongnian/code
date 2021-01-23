	public class Dog
	{
		public virtual void Bark() 
		{ 
			Console.WriteLine("Woof"); 
		}
	} 
	public class BullDog : Dog
	{
                public override void Bark() 
		{
			Console.WriteLine("BOWF!"); 
		}
 
		public void Slobber() 
		{
			Console.WriteLine("I cannot control my drool :("); 
		}
	{
