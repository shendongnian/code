    	public interface IDriviableCar
	{
		object Mileage { get; }
	}
	public interface IRepairableCar
	{
		object Engine { get; }
	}
	public interface IHirableCar
	{
		object MeterReader { get; }
	}
	public class Car : IDriviableCar, IRepairableCar, IHirableCar
	{
		private object _mileage;
		private object _engine;
		private object _meterReader;
		public object Mileage
		{
			get { return _mileage; }
		}
		public object Engine
		{
			get { return _engine; }
		}
		public object MeterReader
		{
			get { return _meterReader; }
		}
	}
