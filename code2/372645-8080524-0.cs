    DateTime dt1 = DateTime.MinValue;
    DateTime dt2 = DateTime.MinValue;
    
    if (DateTime.TryParse(txtStartDate.Text, out dt1) &&
        DateTime.TryParse(txtEndDate.Text, out dt2))
    {
        if (DateTime.Compare(dt1, dt2) > 0) 
        {
         ....
        }
        else
        {
         ....
        }
    }
    else
    {
         // set error stating date time values are not in a parsable format
    }
