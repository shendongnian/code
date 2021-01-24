        static void Main(string[] args)
        {
            createPerson();
            Console.WriteLine("Some display goes here...");
        }
        static void createPerson()
        {
            Console.WriteLine("Please enter the first name: ");
            string fName = getInput();
            if (isExit(fName))
            {
                return;
            }
            Console.WriteLine("Please enter the middle initial: ");
            string mInitial = getInput();
            if (isExit(mInitial))
            {
                return;
            }
            Console.WriteLine("Please enter the last name: ");
            string lName = getInput();
            if (isExit(lName))
            {
                return;
            }
        }
        static string getInput()
        {
            return Console.ReadLine().ToUpper();
        }
        static bool isExit(string value)
        {
            if (value == "EXIT")
            {
                Console.WriteLine("Create person has been canceled by the user.");
                return true;
            }
            return false;
        }
