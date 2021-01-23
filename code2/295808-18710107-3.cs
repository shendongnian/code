    protected void Page_Load(object sender, EventArgs e)
    {
      SetTodaysDateToCompareValidators();
      ...
    }
    protected void SetTodaysDateToCompareValidators()
    {
      string defaultDateFormat = "YYYY-MM-DD";
      string today = DateTime.Today.ToString(defaultDateFormat);
      cvActiveDate.ValueToCompare = today; 
    }
