    // endValue is an input integer 
    decimal acc = 0.0m;
    int factor = 1;
    for (; factor < endValue; factor *= 2)
    {
        try
        {
            acc += (1.0m/(decimal)factor);
        }
        catch
        {
            // we've exceeded bounds of the datatype; return last result
        }
    }
    return acc;
