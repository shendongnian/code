    DateTime SelDate = datePicker.SelectedDate == null ? DateTime.Now : datePicker.SelectedDate;
    
    if( SelDate.Date >= sTime.Date )
    {
       // do something here
    }
