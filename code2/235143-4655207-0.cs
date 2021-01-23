    DateTime today = DateTime.Today;
    DateTime endOfMonth = new DateTime(today.Year, 
                                       today.Month, 
                                       DateTime.DaysInMonth(today.Year, 
                                                            today.Month));
