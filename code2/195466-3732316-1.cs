    private string ToRoman(int number)
    {
        if (number > 0 && number < 4000)
        {
            //ConvertHere
        }
        else
        {
            //Custom exception used for readability purposes.
            throw new NumeralOutOfRangeException();
        }
    }
