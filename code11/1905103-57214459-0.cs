    var i=0;
    while (i < 5)
    {
    	Console.Write("Number {0}: ", i);
        bool Parse = Int32.TryParse(Console.ReadLine(), out outValue);
        if (Parse)
        {
            number[i] = outValue;
            newSum += number[i];
    		i++;
        }
        else
        {
            Console.WriteLine("You Have Entered InValid Format: ");
        }
    }
