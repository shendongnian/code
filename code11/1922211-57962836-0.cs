        public static Double EnterWeight()
        {
            Console.Write("Enter Your Wieght In Pounds: ");
            double Rweight = Convert.ToDouble(Console.ReadLine());
            return Rweight;
        }
        public static double EnterHeight()
        {
            Console.Write("Enter Your Height in Inches: ");
            double Rheight = Convert.ToDouble(Console.ReadLine());
            return Rheight;
        }
        public static double Calculation(double height, double weight)
        {
            double BMI = (weight / Math.Pow(height, 2) * 703);
            return BMI;
        }
        static void Main(string[] args)
        {
            //string name = EnterName();
            //Console.WriteLine(name);
            double weight = EnterWeight();
            //Console.WriteLine(weight);
            double height = EnterHeight();
            //Console.WriteLine(height);
            double BMI = Calculation(height, weight);
            // Notice the {0}. I tell it where in the string to print the
            // argument I passed in out, and the number indicates which argument 
            // to use. Most of .NET formatting works like this.
            Console.WriteLine("Your BMI is: {0}", BMI); 
        }
