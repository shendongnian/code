            for (int i = 1; i < 7; i++)
            {
                current = rNumber.Next(1, 50);
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (current == numbers[j])
                    {
                        Console.WriteLine("Duplicate Found");
                        current = rNumber.Next(1, 50);
                        j = 0; // reset the index iterator
                    }
                }//inner for
                numbers[i] = current; // Store the unique random integer
            }//outer for
