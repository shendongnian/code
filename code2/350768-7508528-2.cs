    for (int i = 0; i < numbers.Length; i++)
    {
        for (int j = i; j < numbers.Length; j++)
        {
            if (numbers[i] == numbers[j] && i!=j)
            {
                Console.WriteLine(numbers[i]);
                break;
            }
        }
    }
