    void Main()
    {
        double[] someArray = { 4.0, 2.0, double.NaN, 1.0, 5.0, 3.0, double.NaN, 10.0, 9.0, 8.0 };
        Array.Sort(someArray, CompareDouble);
        someArray.Dump();
    }
    
    int CompareDouble(double a, double b)
    {
        if (a > b)
            return 1;
        if (a < b)
            return -1;
        return 0;
    }
