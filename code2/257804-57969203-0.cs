    var Date1 = new DateTime(2018, 12, 15);
    var Date2 = new DateTime(2019, 1, 1);
    TimeSpan result1 = Date2.Subtract(Date1);
    Console.WriteLine(result1);
    
    //To calculate difference between two dates use TotalDays() method
    double result2 = Date2.Subtract(Date1).TotalDays;
    Console.WriteLine(result2);
    //Output:
    17.00:00:00
    17
