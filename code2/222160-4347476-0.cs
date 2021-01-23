    void ChangeDate(DateTime dt)
    {
       dt.Year = 2011;
    }
    
    DateTime dt = new DateTime(2010,1,1);
    ChangeDate(dt);
    Console.WriteLine(dt);
