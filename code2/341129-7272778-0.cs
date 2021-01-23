    public class Car
	{
		class Radio
		{
			public void TurnOn()
			{
				// do stuff
			}
		}
		public Car()
		{
                        r = new Radio();
			r.TurnOn();
		}
	}
	public class NotCar
	{
		// i cant use radio
	}
