 private static void WouldYouLikeToContinue()
        {
            Console.Write("Would you like to continue? [n to quit]: ");
            string input = Console.ReadLine();
            if (input.ToLower() == "n")
                Quit();
            Console.Clear(); // <--- This is where I would suggest adding the Clear.
        }
you can use this method after the switch block
    switch (sUserChoice)
    {
        case 1:
            //here i say that to start talking about the parameter that i shall be using
            userName = WelcomeToTheSystem();
            break;
        case 2:
            // here i call apon the parameter used
            Grades();
            break;
        case 3:
            // here i call apon the parameter used
            Months();
            break;
        case 4:
            // here i call apon the parameter used
            AddingNegitiveAndPossitiveNumbers();
            break;
        // here i call apon the parameter used
        case 0:
            Quit();
            break;
        }        
        WouldYouLikeToContinue(); // <----- HERE
    } while (sUserChoice != 0);
    
NOTE: Your method to validate data... has a syntax error.
if (iNumber < -11 || iNumber > 11) // iNumber should be > 11 (not < 11)
