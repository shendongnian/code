    int n2 = int.Parse(Console.ReadLine());
    int n3 = int.Parse(Console.ReadLine());
    for (int i = n2; i < n3; i++)
    {
        int sum = 0;
        for (int j = 1; j < i; j++)  // you need to exclude the number itself. So use Loop condition j <i, instead of j <=i
        {
            if (i % j == 0 )
			{
                sum = sum + j;
				
			}
        }      
		if (sum == i )  // Validate the sum with the number only after calculating sum of all divisors.
                    {
			Console.WriteLine("the sum is " + i);
		}
    }
