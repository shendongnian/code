	public interface IFrontEndEntity<TEntity>
	{
		TEntity GetEntity();
	}
	public static class FrontEndExtensions
	{
		public static IEnumerable<TEntity> GetEntities<TEntity>(this IEnumerable<IFrontEndEntity<TEntity>> frontEndItems)
		{
			return frontEndItems.Select(a => a.GetEntity());
		}
	}
	public class Dog
	{
	}
	public class DogFrontEnd : IFrontEndEntity<Dog>
	{
		public Dog Entity { get; set; }
		public Dog GetEntity()
		{
			return Entity;
		}
	}
	public class Main
	{
		public void Run()
		{
			IEnumerable<DogFrontEnd> dogFronEnds = new List<DogFrontEnd>();
			IEnumerable<Dog> dogs = dogFronEnds.GetEntities();
		}
	}
