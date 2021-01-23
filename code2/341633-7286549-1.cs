    static void Main(string[] args)
            {
                double sideA = 0;
                double sideB = 0; 
                double sideC = 0; 
                Console.Write("Enter an integer for Side A ");
                sideA = Convert.ToDouble(Console.ReadLine()); 
                Console.Write("Enter an integer for Side B ");
                sideB = Convert.ToDouble(Console.ReadLine()); 
                sideC = Math.Pow((sideA * sideA + sideB * sideB), .5); 
                Console.Write("Side C has this length..."); 
                Console.WriteLine(sideC); 
                Console.ReadLine();
            }
