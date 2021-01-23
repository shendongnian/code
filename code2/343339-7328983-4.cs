    DateTime complaintDate = GetDateFromDatabase();
    int totalDays = (int)(DateTime.Now - complaintDate).TotalDays;
    if (totalDays >= 20)
    {
        // Perform your actions here. 20+ days have elapsed.
    }
