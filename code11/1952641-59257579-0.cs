    bool isValid = false;
    while(!isValid)
    {
        Console.WriteLine("Please give me 2 number between -10 and +10 and I'll add them together");
        Console.Write("Please enter a number: ");
        iNumber1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Please enter a number: ");
        iNumber2 = Convert.ToInt32(Console.ReadLine());
        isValid = areValid(iNumber1, iNumber2);
        if(!isValid)
        {
           Console.WriteLine("Out of range calculation is ignored");
        }
    }
