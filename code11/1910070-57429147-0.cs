    int year = int.Parse(YearField.Text);
    int month = int.Parse(MonthField.Text);
    int day = int.Parse(DayField.Text);
    
    try {
        DateTime date = new DateTime(year, month, day);
    catch (ArgumentOutOfRangeException) {
        //Date is invalid
    }
