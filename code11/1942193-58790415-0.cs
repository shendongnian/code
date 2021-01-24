    for (int inc = 1; inc < amount; inc++)
            {
                numberInputs[inc] = int.Parse(Console.ReadLine());
                if (inc % 2 == 0)
                {
                    sumEven *= numberInputs[inc];
                }
                else
                {
                    sumOdd *= numberInputs[inc];
                }
            }
