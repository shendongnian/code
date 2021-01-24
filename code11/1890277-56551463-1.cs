	public class BirdCage
	{
		public BirdCage([Bird]IAnimal bird) => Bird = bird;
		public IAnimal Bird { get; }
	}
	public class Zoo
	{
		public Zoo([Monkey]IAnimal monkey, [Bird]IAnimal bird)
		{
			Monkey = monkey;
			Bird = bird;
		}
		public IAnimal Monkey { get; }
		public IAnimal Bird { get; }
	}
