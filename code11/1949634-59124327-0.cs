    while (i < 10)
    {
        i++;
        Console.WriteLine("Enter number:"); 
        number_s = Console.ReadLine(); 
		if(string.IsNullOrEmpty(number_s))
			break;
		input = Convert.ToInt32(number_s);
		sum += input;
    }
    Console.WriteLine("The sum of the entered numbers are : {0}", sum);
