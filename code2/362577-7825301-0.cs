    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace SOHelp
    {
        class Program
        {
            static void Main(string[] args)
            {
                  //DECLARATIONS
            double circleArea;  // area of pizza
            double diameter; // diameter of the pizza
            double areaOfSlice; // area of the slices
            double radius; // half the diameter of the pizza
            double slices = 0; // number of pizza slices
            string message = ""; // a string to hold a message to the user
            const int DIAMETER_RANGE_MASSIVE = 36;
            const int DIAMETER_RANGE_EXTRA_LARGE = 30;
            const int DIAMETER_RANGE_LARGE = 24;
            const int DIAMETER_RANGE_MED = 16;
            const int DIAMETER_RANGE_LOW = 12; // Low end on range scale for diameter
            const int SLICES_LOW_DIAMETER = 8; // number of pizza slices based on diameter
            const int SLICES_MID_DIAMETER = 12; // number of pizza slices based on diameter
            const int SLICES_HIGH_DIAMETER = 16; // number of pizza slices based on diameter
            const int SLICES_GIANT_DIAMETER = 24; // number of pizza slices based on diameter        
            bool needInput = true;
            const int END_PROGRAM = 0;
    
    
    
    
            // INPUT
            // Prompt for and get keyboard input
    
          
            // convert that string to an double,
            // assign the resulting value to diameter
    
            // PROCESSING
            // determine if diameter meets requirements of 12" to 36"
            // if does not meet requirements show error message and have user enter in new diameter
            string message = "Please enter the diameter of your pizza (0 to end program): ";
    
            do
            {
                Console.Write(message);  // get user to input diameter
                diameter = Convert.ToDouble(Console.ReadLine()); // read a line of text (string) from the keyboard,
    
                if (diameter < DIAMETER_RANGE_LOW || diameter > DIAMETER_RANGE_MASSIVE)
    
                {
                    message = "\nENTRY ERROR";
                    message += "\nPizza must have a diameter in the range of 12” to 36” inclusive!";
                    message += "\nPlease try again.";
                }
    
    
    
            else {    
                needInput = false;
                    // determine the number of slices based on diameter
    
    
                    if (diameter >= DIAMETER_RANGE_LOW && diameter < DIAMETER_RANGE_MED)
                    {
                        slices = (SLICES_LOW_DIAMETER);
                    }
                    else if (diameter < DIAMETER_RANGE_LARGE)
                    {
                        slices = (SLICES_MID_DIAMETER);
                    }
                    else if (diameter < DIAMETER_RANGE_EXTRA_LARGE)
                    {
                        slices = (SLICES_HIGH_DIAMETER);
                    }
                    else
                    {
                        slices = (SLICES_GIANT_DIAMETER);
                    }
    
                    Console.Clear(); // clears console to show new output lines
                    //OUTPUT
                    for (int slicesAddFour = 8; slicesAddFour <=slices; slicesAddFour+=4) // for each slices
                    {
                    // determine the area of the slices
                    radius = diameter / 2; // uses diameter to get radius
                    circleArea = Math.PI * Math.Pow(radius, 2); // uses math class to calculate circle area  
                    areaOfSlice = Math.Round((circleArea / slices), 2); // divides circle area by slices, takes the result of above calculation and rounds
    
                    Console.WriteLine("\nA {0}\" Pizza diameter: {0}\".", diameter); 
                    message +=("\n==============================================");
                    Console.WriteLine("\nCut in {0} slices results in an area of {1}\" per slice.",areaOfSlice,slices);
    
                    }
    
    
            } //end of else
    
                message = ("\nPlease enter the diameter of your pizza (0 to end program)");
                needInput = true;
            } while (diameter != END_PROGRAM && needInput);
        }
    }
            }
