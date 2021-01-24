	public interface IFruit { }
	
	public abstract class BowlOf<Fruit> where Fruit : IFruit
	{
		public void Add(Fruit fruit) { }
	}
	
	public class Apple : IFruit { }
	
	public class BowlOfApples : BowlOf<Apple> { }
