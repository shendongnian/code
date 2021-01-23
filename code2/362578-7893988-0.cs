    using System;
    
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Lab6B
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
                const int INPUT_MAX = 36; // maximum entry for diameter
                const int DIAMETER_RANGE_EXTRA_LARGE = 30; // diameter range used to figure out slices
                const int DIAMETER_RANGE_LARGE = 24; // diameter range used to figure out slices
                const int DIAMETER_RANGE_MED = 16; // diameter range used to figure out slices
                const int INPUT_MIN = 12; // minimum entry for diameter
                const int SLICES_LOW_DIAMETER = 8; // number of pizza slices based on diameter
                const int SLICES_MID_DIAMETER = 12; // number of pizza slices based on diameter
                const int SLICES_HIGH_DIAMETER = 16; // number of pizza slices based on diameter
                const int SLICES_GIANT_DIAMETER = 24; // number of pizza slices based on diameter        
                bool needInput = true; // does the program need input true or false
                const int END_PROGRAM = 0; // 0 ends the program
    
    
                
           
    
                // INPUT
                // Prompt for and get keyboard input
    
                Console.Write("Please enter the diameter of your pizza: ");  // get user to input diameter
                diameter = Convert.ToDouble(Console.ReadLine()); // read a line of text (string) from the keyboard, 
                
                // convert that string to an double,
                // assign the resulting value to diameter
                
                while (diameter != END_PROGRAM && needInput) // Begin while loop
    
                {
    
                    // PROCESSING
                   
                    // determine if diameter meets requirements of 12" to 36"
                    // if does not meet requirements show error message and have user enter in new diameter
    
    
                    if (diameter < INPUT_MIN || diameter > INPUT_MAX)
                    {
    
                        Console.WriteLine( "\nENTRY ERROR\nPizza must have a diameter in the range of 12” to 36” inclusive!\nPlease try again.");
                    }
    
    
                    else
                    {
                        needInput = false;
                        // determine the number of slices based on diameter
    
    
                        if (diameter < DIAMETER_RANGE_MED)
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
    
                        Console.WriteLine("\nA {0}\" Pizza diameter: {0}\".", diameter);
                        Console.WriteLine("\n==============================================");
    
                        for (int slicesAddFour = 8; slicesAddFour <= slices; slicesAddFour += 4) // for each slices
                        {
                            // determine the area of the slices
                            radius = diameter / 2; // uses diameter to get radius
                            circleArea = Math.PI * Math.Pow(radius, 2); // uses math class to calculate circle area  
                            areaOfSlice = Math.Round((circleArea / slicesAddFour), 2); // divides circle area by slices, takes the result of above calculation and rounds
    
    
                            Console.WriteLine("\nCut in {0} slices results in an area of {1}\" per slice.", slicesAddFour, areaOfSlice);
                            
    
                        }
                         
    
                    } //end of else
                     
                    Console.Write("\nPlease enter the diameter of your pizza (0 to exit): ");
                    diameter = Convert.ToDouble(Console.ReadLine());
                    Console.Clear(); // clears console to show new output lines
                    
                    // set the need input value back to true for new entry
                    needInput = true;
                    
                 } // end of while loop
            }
        }
    }
       
                   
