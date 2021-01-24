            double width, height, woodLength, glassArea; string widthString, heightString;
            width = GetValidDblInput("Please enter the width:");
            height = GetValidDblInput("Please enter the height:");
            woodLength = 2 * (width + height) * 3.25;
            glassArea = 2 * (width * height);
            Console.WriteLine("The length of the wood is " + woodLength + " feet");
            Console.WriteLine("The area of the glass is " + glassArea + " square metres");
            Console.ReadLine();
        }
        static double GetValidDblInput(string inputRequest)
        {
            bool IsValid = false;
            double val = 0;
            while(!IsValid)
            {
                Console.WriteLine(inputRequest);
                if(double.TryParse(Console.ReadLine(), out val))
                {
                    IsValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid value (e.g. 1, 3.25, 400)");
                }
            }
            return val;
        }
