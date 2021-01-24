c#
static void Main(string[] args)
{
	double kilograms = ConsoleConvertors.LbsToKg();
	double Mts = ConsoleConvertors.InchToMeters();
	double BMiMet = ConsoleConvertors.BMIMetrics();
	double BMICat = ConsoleConvertors.BMICategories();
}
public static class  ConsoleConvertors
{
	public static double LbsToKg()
	{
		Console.WriteLine("LbsToKg - Enter lsb:");
		var lbs = Convert.ToDouble(Console.ReadLine());
		double kilograms = lbs * 0.45359237;
		Console.WriteLine(lbs + " pounds is " + kilograms + " kilograms");
		return kilograms;
	}
	public static double InchToMeters()
	{
		Console.WriteLine("InchToMeters - Enter inch:");
		var inches = Convert.ToDouble(Console.ReadLine());
		double meters = inches / 39.37;
		Console.WriteLine(inches + " inches is " + meters + " meters");
		return meters;
	}
	public static double BMIMetrics( )
	{
		Console.WriteLine("BMIMetrics - Enter kilograms :");
		var kilograms = Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("BMIMetrics - Enter meters :");
		var metter = Convert.ToDouble(Console.ReadLine());
		double bmi = kilograms / (metter * metter);
		Console.WriteLine("Your BMI is:{0}", Math.Round(bmi, 4));
		return bmi;
	}
	public static double BMICategories()
	{
		Console.WriteLine("BMICategories - Enter bmi :");
		var bmi = Convert.ToDouble(Console.ReadLine());
		if (bmi < 18.5)
			Console.WriteLine("You are underweight.");
		else if (bmi > 18.5 && bmi < 24.9)
			Console.WriteLine("You're normal weight.");
		else if (bmi > 25.0 && bmi < 29.9)
			Console.WriteLine("You're Overweight.");
		else if (bmi > 30.0)
			Console.WriteLine("You are Obese");
		
		return bmi;
	}
}
