    var date = DateTime.Today;
    MakeMinValue(ref date);
    Console.Out.WriteLine("date = {0}", date);
    public void MakeMinValue(ref DateTime dateTime)
    {
        dateTime = DateTime.MinValue;
    }
