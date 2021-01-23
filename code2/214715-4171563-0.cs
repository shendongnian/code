 class Request
    {
        public static void GetPhoneNumber(out string UserInput, out string ConvertedString)
        {
            // create instance of ConsoleKeyInfo
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            string alphaNumericPhoneNumber = " ";
            string numericPhoneNumber = " ";
            char input = ' ';
            Console.Write("Please enter your phone number: ");
            // perform a do... while loop to read 10 characters of input
            do
            {                
                cki = Console.ReadKey();
                input =  cki.KeyChar;                
                switch (char.ToUpper(input))
                {
                    case '0':
                        alphaNumericPhoneNumber += input.ToString();
                        numericPhoneNumber += input.ToString();
                        break;
                    case '1':
                        alphaNumericPhoneNumber += input.ToString();
                        numericPhoneNumber += input.ToString();                        
                        break;
                    case 'A':
                    case 'B':
                    case 'C':
                    case '2':
                        alphaNumericPhoneNumber += input.ToString();
                        numericPhoneNumber += "2";                        
                        break;
                    case 'D':
                    case 'E':
                    case 'F':
                    case '3':
                        alphaNumericPhoneNumber += input.ToString();
                        numericPhoneNumber += "3";                        
                        break;
                    case 'G':
                    case 'H':
                    case 'I':
                    case '4':
                        alphaNumericPhoneNumber += input.ToString();
                        numericPhoneNumber += "4";                        
                        break;
                    case 'J':
                    case 'K':
                    case 'L':
                    case '5':
                        alphaNumericPhoneNumber += input.ToString();
                        numericPhoneNumber += "5";                        
                        break;
                    case 'M':
                    case 'N':
                    case 'O':
                    case '6':
                        alphaNumericPhoneNumber += input.ToString();
                        numericPhoneNumber += "6";                        
                        break;
                    case 'P':
                    case 'Q':
                    case 'R':
                    case 'S':
                    case '7':
                        alphaNumericPhoneNumber += input.ToString();
                        numericPhoneNumber += "7";                        
                        break;
                    case 'T':
                    case 'U':
                    case 'V':
                    case '8':
                        alphaNumericPhoneNumber += input.ToString();
                        numericPhoneNumber += "8";                        
                        break;
                    case 'W':
                    case 'X':
                    case 'Y':
                    case 'Z':
                    case '9':
                        alphaNumericPhoneNumber += input.ToString();
                        numericPhoneNumber += "9";                        
                        break;
                    default:
                        // if input does not match cases then loop returns to 
                        // request new input
                        Console.Clear();
                        Display.Error(input.ToString());
                        // display for user to continue... displays valid numbers so far
                        Console.Write("Continue with phone number: " + alphaNumericPhoneNumber);                        
                        input = ' '; // returns blank character and not added to strings so not counted
                        break;
                }
            }
            while (numericPhoneNumber.Length < 11); // counts until string has 10 digits
            UserInput = alphaNumericPhoneNumber;
            ConvertedString = numericPhoneNumber;
        }
    }
