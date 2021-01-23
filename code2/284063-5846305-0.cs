	class Program
	{
		static void Main (string[] args)
		{
			Car c = new Car ("Frank", 55);
			c.colour = "Green";
			
			Console.WriteLine ("Name = : {0}", c.PetName);
			c.DisplayStats ();
			
			Garage carLot = new Garage ();
			
			// Hand over each car in the collection
			foreach (Car ch in carLot) {
				Console.WriteLine ("{0} is going {1} MPH", ch.PetName, ch.Speed);
			}
			
			Console.ReadLine ();
		}
		class Car
		{
			//Automatic Properties
			public string PetName { get; set; }
			public int Speed { get; set; }
			public string colour { get; set; }
			public void DisplayStats ()
			{
				Console.WriteLine ("Car Name: {0}", PetName);
				Console.WriteLine ("Speed: {0}", Speed);
				Console.WriteLine ("Color: {0}", colour);
			}
			
			public Car(string petname, int speed) { PetName = petname; Speed = speed; }
		}
		public class Garage : IEnumerable
		{
			private Car[] carArray = new Car[4];
			// Fill with some car objects on startup.
			public Garage ()
			{
				carArray[0] = new Car ("Rusty", 30);
				carArray[1] = new Car ("Clunker", 55);
				carArray[2] = new Car ("Zippy", 30);
				carArray[3] = new Car ("Fred", 30);
			}
			
			public IEnumerator GetEnumerator ()
			{
				foreach (Car c in carArray) {
					yield return c;
				}
			}
			
		}
		
	}
