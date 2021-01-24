    class Program
    {
        static void Main(string[] args)
        {       
            double kgs = LbsToKg();
            double mts = InchToMeters();
            double bmiMet = BMIMetrics(kgs, mts);
            double bmiCat = BMICategories(bmiMet);
            Console.ReadLine();
        }
		// you don't need paramteter - you collect it from the user
        public static  double LbsToKg()
        {
            double lbs = Convert.ToDouble(Console.ReadLine());
            double kilograms = lbs * 0.45359237;
            Console.WriteLine(lbs + " pounds is " + kilograms + " kilograms");
            Console.ReadLine();
            return kilograms;
        }
		// you don't need paramteter - you collect it from the user
        public static double InchToMeters()
        {
            double inches = Convert.ToDouble(Console.ReadLine());
            double meters = inches / 39.37;
            Console.WriteLine(inches + " inches is " + meters + " meters");
            return meters;
        }
		
        public static double BMIMetrics(double kilograms, double meters)
        {
            double bmi = kilograms / (meters * meters);
            Console.WriteLine("Your BMI is:{0}", Math.Round(bmi, 4));
            return bmi;
        }
		
        public static void BMICategories(double bmi)
        {
            if (bmi < 18.5)
                Console.WriteLine("You are underweight.");
            else if (bmi > 18.5 && bmi < 24.9)
                Console.WriteLine("You're normal weight.");
            else if (bmi > 25.0 && bmi < 29.9)
                Console.WriteLine("You're Overweight.");
            else if (bmi > 30.0)
                Console.WriteLine("You are Obese"); 
        }
        
    }
