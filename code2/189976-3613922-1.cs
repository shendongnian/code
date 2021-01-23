            bool isOk = true;
            foreach (char c in input.ToArray())
            {
                if (!Char.IsDigit(c))
                {
                    Console.WriteLine("You have to enter four DIGITS");
                    isOk = false;
                    break;
                }
            }
