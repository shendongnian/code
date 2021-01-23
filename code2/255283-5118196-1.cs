    var startDate = ReadStartDateFromFile();
    if(DateTime.Now.Subtract(startDate).TotalDays < 2 || startDate == new DateTime())
        Application.Run(new Form1());
    else
        Application.Run(new Form2());
