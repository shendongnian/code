    DateTime stdate = Datetimepicker1.value;
    while (stdate <= DateTime.Now)
    {
        txtSelectedDate.Text = stdate.ToString("yyyyMMdd");
        selectedDate = txtSelectedDate.Text;
    
    /* Here use your existing code as it is */
    ............
    .........
    
    
    
    stdate = stdate.AddDays (1); // It will get next date till present
    
    }
