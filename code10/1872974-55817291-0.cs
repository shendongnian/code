    var queryTestedControls = from t in dbContext.UUT_RESULT
							  where t.PART_NAME.Contains(ControlSelected)
							  select t;
    var queryPassedControls = from t in dbContext.UUT_RESULT
							  where t.PART_NAME.Contains(ControlSelected)
							  select t;									
							  
	if (btnUseDateRange.Text == "Disabled")
	{
		lblTested.Text = queryTestedControls.Where(t => t.UUT_SERIAL_NUMBER.CompareTo(BarcodeStart) >= 0 &&
									t.UUT_SERIAL_NUMBER.CompareTo(BarcodeEnd) <= 0).Count().ToString();
								
		lblPassed.Text = queryPassedControls.Where(t => t.UUT_SERIAL_NUMBER.CompareTo(BarcodeStart) >= 0 &&
									t.UUT_SERIAL_NUMBER.CompareTo(BarcodeEnd) <= 0 &&
									t.UUT_STATUS == "Passed").Count().ToString();
	}
	else if (btnUseDateRange.Text == "Enabled")
	{
		lblTested.Text = queryTestedControls.Where(t => t.START_DATE_TIME >= DateStart &&
									t.START_DATE_TIME <= DateEnd).Count().ToString();
								
		lblPassed.Text = queryPassedControls.Where(t => t.START_DATE_TIME >= DateStart && 
									t.START_DATE_TIME <= DateEnd && 
									t.UUT_STATUS == "Passed").Count().ToString();
	}
	
