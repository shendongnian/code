    static void Main()
    {
        // Since I'm working with instances, I tend to pass the actual 
        // measured amount in as well...  However, you could leave this out (or pass 1)
        var len = Length.Create(42, "in"); 
        double conversionFactory = len.ConversionFactorToSI;
    }
