        static void Main(string[] args)
        {
            
            double Num;
            // declaring "Num" as a double
            
            Console.WriteLine("Please enter dollar and cents amount\nExample: 4.52");
            //This bit of code informs the user what type of information you want from them
            
            Num = double.Parse( Console.ReadLine());
            //assigns "Num" to the users input and sets the user input as numerical value and stores it in the temporary memory
            Console.WriteLine("You have {1} dollars and {2} cents from {0:c}.", Num, WhyAreWeDoingThis(ref Num), Num);
            //returns the values requested and sends "Num" through the program to separate dollars from cents.
            //first: off in{0:c} it takes the original user input and gives it the dollar sign$ due to the additional code to the left of the zero as shown {0:c}
            //second: "Num" is sent to the WhyAreWeDoingThis Method through the reference method "ref" where the dollar amount is separated from the cent amount
            //*Note* this will only return the dollar amount not the cents*
            //Third: the second "Num" referred to at this point is only the remaining cents from the total money amount. 
            //*Note* this is because the program is moving "Num" around as a stored value from function to function not grabbing the users original input every time.
            
            Console.ReadLine();
            //this keeps the program open
        }
        static int WhyAreWeDoingThis(ref double A)
            // reference method
            //*Note* it is set as a "static int" and (ref double)
            
        {
            int dd = (int)A;
            //this turn the double into a temporary integer by type casting for this one operation only.
            A = A % dd;
            //Separates the dollars from the cents leaving only the cents in the "Num" value through the Modulus Operand.
            return dd;
            //returns the dollar amount.
        }
    }
