    if (inputNumberGrade == maxGrade)
    {
        Console.WriteLine("perfect you got an {0}", perfectGrade);
    }
    else if (inputNumberGrade <= 99 && inputNumberGrade >= 80)
    {
        Console.WriteLine($"You got an {goodGrade}");
    }
    else if (inputNumberGrade <= 79 && inputNumberGrade >= 70)
    {
        Console.WriteLine($"You got a {okGrade}");
    }
    else if (inputNumberGrade <= 69 && inputNumberGrade >= 60)
    {
        Console.WriteLine($"You got a {fairGrade}");
    }
    else if (inputNumberGrade <= 59 && inputNumberGrade >= 50)
    {
        Console.WriteLine("Poor performance, you got a {0}", passGrade);
    }
    else if (inputNumberGrade >= 40 && inputNumberGrade <= 49)
    {
        Console.WriteLine($"You fail, you got an {failGrade}");
    }
    else if (inputNumberGrade < 40 && inputNumberGrade != 0)
    {
        Console.WriteLine($"You fail, you got an {failGrade}");
    }
    else if ((inputNumberGrade != 0) == (inputNumberGrade == maxGrade))
    {
        //Re-enter score to reflect whether or not the end-result is a positive or negative letter grade
        Console.Write("Re-enter Score: ");
        GetInputNumberGrade(inputNumberGrade);
    }
    Console.ReadKey();
