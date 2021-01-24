    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace bmiCalculator
    {
        class Program
        {
            static void Main(string[] args)
            {
                double kg = LbsToKg();
                double m = InchToMeters();
                double bmi = BMIMetrics(kg, m);
    
                BMICategories(bmi); 
    
                Console.ReadLine();
            }
    
            public static double LbsToKg()
            {
                Console.Write("Weight in lbs: ");
                double lbs = Convert.ToDouble(Console.ReadLine());
                double kilograms = lbs * 0.45359237;
                Console.WriteLine(lbs + " pounds is " + kilograms + " kilograms");
                return kilograms;
            }
    
            public static double InchToMeters()
            {
                Console.Write("Height in inches: ");
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
    }
