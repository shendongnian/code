       class Program
       {
        public const string Lb = "lb"; //User options as constants
        public const string Kg = "kg";
        static void Main(string[] args)
        {
            string userInput = GetUserInput();
            try
            {
                ConvertUserInput(userInput);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message); // Show error message
                userInput = GetUserInput(); // Get user input again
                ConvertUserInput(userInput);
            }
            Console.ReadLine();
        }
        private static string GetUserInput()
        {
            Console.Write("Enter either lb or kg:");
            string userInput = Console.ReadLine();
            return userInput;
        }
        private static void ConvertUserInput(string userInput)
        {
            // Guard for throwing an error when the user enters another value
            if (!IsValidUserInput(userInput))
                throw new ArgumentException("Input value is not lb or kg");
            if (ConvertFromPoundsToKg(userInput)) // where the error occurs
            {
                var k = new ConvertNumber();
                k.ConvertLb();
            }
            else
            {
                var l = new ConvertNumber();
                l.ConvertKg();
            }
        }
        /// <summary>
        /// userInput is either "lb" or "kg"
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        private static bool IsValidUserInput(string userInput)
        {
            return ConvertFromPoundsToKg(userInput) || (ConvertFromKgToPounds(userInput));
        }
        private static bool ConvertFromKgToPounds(string userInput)
        {
            return userInput == Kg;
        }
        private static bool ConvertFromPoundsToKg(string userInput)
        {
            return userInput == Lb;
        }
    }
 
