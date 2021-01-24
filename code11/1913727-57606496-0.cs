    public static void dummy(days Daysofweek)
    {
        int val = (int) Daysofweek;
        bool hasMultipleFlagsSet = val != 0 && (val & (val - 1)) == 0;
        if(hasMultipleFlagsSet){/*some function*/}
        else {/*some other  function*/}
        Console.WriteLine(Daysofweek.ToString());
    }
