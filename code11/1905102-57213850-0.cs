for (int i = 0; i < number.Length; i++)
            {
                Console.Write("Number {0}: ", i);
                bool Parse = Int32.TryParse(Console.ReadLine(), out outValue);
                if (Parse)
                {
                    number[i] = outValue;
                    newSum += number[i];
                }
                else
                {
                    i--;
                    Console.WriteLine("You Have Entered InValid Format: ");
                }
            }
