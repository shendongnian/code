	enum Temperature
	{
		Celcius,
		Fahrenheit,
		Kelvin
	}
	class TemperatureConverter : UnitConverter<Temperature, float>
	{
		static TemperatureConverter()
		{
			BaseUnit = Temperature.Celcius;
			RegisterConversion(Temperature.Fahrenheit, v => v * 2f, v => v * 0.5f);
			RegisterConversion(Temperature.Kelvin, v => v * 10f, v => v * 0.05f);
		}
	}
