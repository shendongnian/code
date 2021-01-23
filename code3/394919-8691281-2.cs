    public void ExceptFunctioni()
    {
        int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
        int[] numbersB = { 1, 3, 5, 7, 8 };
        IEnumerable<int> aOnlyNumbers = numbersA.Except(numbersB);
        if(aOnlyNumbers.Count()>0)
        {
            // do something
        }
    }
