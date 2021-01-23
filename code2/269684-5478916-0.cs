    static List<string> RecursiveGet(DateTime StartDate, DateTime EndDate, List<string> Output)
    {
        if (Webservice.RecordCount > 9999)
        {
            TimeSpan T = EndDate.Subtract(StartDate);
            T = new TimeSpan((long)(T.Ticks / 2));
            DateTime MidDate = StartDate.Add(T);
            Output.AddRange(RecursiveGet(StartDate, MidDate, Output));
            Output.AddRange(RecursiveGet(MidDate.AddMilliseconds(1), EndDate, Output));
        }
        else
        {
            //Get Records here, return them in array
            Output.Add("Test");
        }
        return Output;
    }
    static List<string> GetRecords(DateTime StartDate, DateTime EndDate)
    {
        return RecursiveGet (StartDate, EndDate, new List<string>());
    }
