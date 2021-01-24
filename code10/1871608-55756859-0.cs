            do
            {
                Console.WriteLine("\nSet a date :");
                correctInput = int.TryParse(Console.ReadLine(), out dateInput);
                if (!correctInput || dateInput > 31 || dateInput < 1)
                {
                    Console.WriteLine("Incorrect Input!");
                }
                else
                {
                    if (dateInput > DateTime.DaysInMonth(yearInput, monthInput))
                    {
                        Console.WriteLine("The date doesn't reach that many!");
                        correctInput = false; // Makes one more iteration of the loop
                    }
                }
            } while (!correctInput || dateInput > 31 || dateInput < 1);
