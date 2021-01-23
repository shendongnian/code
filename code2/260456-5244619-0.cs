    int hours =  DateTime.Now.Hour;
    
    if(hours >= 6 and hours <= 14)
    {
    combobox1.SelectedIndex = 0; //Assuming the TimeZone 1 is the first item.
    }
    else if(hours > 14 and hours <= 22)
    {
    combobox1.SelectedIndex = 1; //Assuming the TimeZone 2 is the second item.
    }
    else
    {
    combobox1.SelectedIndex = 2; //Assuming the TimeZone 3 is the third item.
    }
