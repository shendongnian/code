    using static System.Console;
    void do_lottery()
    {
        while (true)
        {
            Write("Enter 6 digits, divided by comma: ");
            var input = ReadLine();
            var user_numbers = input.Split(",").Select(n => int.Parse(n));
            var numbers_to_guess = new[] { 6, 23, 12, 46, 8, 2 };
            if (user_numbers.All(n => numbers_to_guess.Any(z => z == n)))
            {
                WriteLine("You won!");
            }
            else
            {
                WriteLine("You lose!");
            }
            Write("Do you wanna play once again? (Y/N): ");
            var answer = ReadLine().ToUpper();
            if (answer != "Y") break; //Exit loop
        }
        WriteLine("Lottery finished.");
    }
