       string myChoice;
       do
       {
            // Print A Menu
            Console.WriteLine("My Address Book\n");
            Console.WriteLine("A - Add New Address");
            Console.WriteLine("D - Delete Address");
            Console.WriteLine("Q - Quit\n");
            Console.WriteLine("Choice (A,D,M,V,or Q): ");
            myChoice = Console.ReadLine();
            // Make a decision based on the user's choice
            switch(myChoice)
            {
                case "A":
                    Console.WriteLine("You wish to add an address.");
                    break;
                case "D":
                    Console.WriteLine("You wish to delete an address.");
                    break;
                case "Q":
                    Console.WriteLine("Bye.");
                    break;
            }
            Console.ReadLine();
            Console.WriteLine();
        } while (myChoice != "Q" && myChoice != "q"); // Keep going until the user wants to quit
