    Console.Write("Enter the number of the Row you would like to see the sum of: ");
    string input = Console.ReadLine();
    int h;
    //validates the input more safely
    if(int.TryParse(input, out h) && h >= 0 && h < 6)
    {
        int sum = 0;
        //loop over only the row that you care about
        for(int i = 0; i < 6; i++)
            sum += array1[h, i];
        Console.WriteLine("The sum of Row {0} is {1} ", h, sum);
    }
    else
    {
        Console.WriteLine(-1);
    }
