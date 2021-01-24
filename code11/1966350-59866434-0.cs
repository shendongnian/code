cs
        static void Main(string[] args)
        {
            string firstName;
            string lastName;
            Console.WriteLine("What is your First Name?");
            firstName = Console.ReadLine();
            Console.WriteLine("What is your Last Name?");
            lastName = Console.ReadLine();
            char capitalFirst = firstName[0]; // writes first letter of the name as a char
            char capitalLast = lastName[0];
            if (char.IsLower(capitalFirst)) { //checks if char is lowercase 
                firstName = capitalise(firstName, capitalFirst);
                lastName = capitalise(lastName, capitalLast); 
            }
            //Same for last name...
            Console.WriteLine(firstName + " " + lastName);
        }
