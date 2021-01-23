    DateTime start = DateTime.Now;
    for (var i = 0; i < 1000000; i++)
    {
        double result = (double)22 / 7;
        result = System.Math.Round(result, digit);
    }
    DateTime end = DateTime.Now;
    double milliseconds = (end - start).TotalMilliseconds / 1000000;
