    List<DayOfWeek> userType = null;
    
    if (rbDaily.Checked || cbTwoWeeks.Checked)
    {
        userType = new List<DayOfWeek>();
        if (checkboxMon.Checked)
        { 
            userType.Add(DayOfWeek.Monday);
        }
        if(checkboxWed.Checked)
        { 
            userType.Add(DayOfWeek.Wednesday);
        }
    }
