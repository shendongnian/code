    bool inc = true;
    for (int i = 1; i < inputList.Count; i++)
    {
        if (inputList[i] < inputList[i - 1])
        {
           inc=false;
           break;
        }
    }
    
    Console.WriteLine($"List has consecutive numbers: {(inc?"yes":"no")}");
