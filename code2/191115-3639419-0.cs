	public interface IUnit
	{
		T Add<T>(T unit) where T : IUnit<T>;
	}
	public interface IUnit<T>
	{
		T Add(T unit);
	}
        abstract class Unit : IUnit
        {
        }
      
        class Measure : Unit, IUnit<Measure>
        {
		public Measure Add(Measure unit)
		{
			throw new NotImplementedException();
		} 
        }
        class Weight : Unit, IUnit<Weight>
        {
		public Weight Add(Weight unit)
		{
			throw new NotImplementedException();
		}
        }
