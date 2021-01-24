    int year = 2019;
    int month = 4;
    
    int[] days = Enumerable.Range(1, DateTime.DaysInMonth(year, month)).ToArray();
    int[] years = Enumerable.Range(DateTime.Now.Year, 2050).ToArray();
    string[] months = new string[]{"Jan","Feb","Mar","..."};
    
    comboBoxDays.DataSource = days;
    comboBoxDays.DataBind();
    
    comboBoxYears.DataSource = years;
    comboBoxDays.DataBind();
    
    comboBox1Month.DataSource = months;
    comboBoxDays.DataBind();
