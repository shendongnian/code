    void UserInput(string input)
            {
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Invalid Response");
                    return;
                }
                Console.WriteLine($"You choose {input}");
            }
