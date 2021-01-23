    //DECLARATION OF VARIABLES
            string Diameter = null;           //The diameter of the pizza which the user will enter
            int Slices;                       //The number of slices the user will get
            const double SliceSize = 14.125;  //The area of each slice of pizza
            double Radius;                    //The radius of the pizza
            double Area;                      //The area of the pizza
            //INPUT
            Console.Write("Enter diameter of pizza: ");
            Diameter = Console.ReadLine();
            double Diameter1 = Convert.ToDouble(Diameter);
            //PROCESS
            Radius = Diameter1 / 2;
            Area = Math.PI*Math.Pow(Radius,2);
            Slices = (int)Math.Round(Area / SliceSize);
            //OUTPUT
            Console.WriteLine("A " + Diameter + "\" pizza will yeild {0:n0} slices", Slices);
            // END - pause the program so the user can read the output and waits for user to press any key to exit the console
            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
