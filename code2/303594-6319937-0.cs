    int idate = Convert.ToInt32(dateTimePicker1.Text);
    int itodate = Convert.ToInt32(dateTimePicker2.Text);
    
    while (idate <= itodate) {
        try
        {
            writerdelete1.OpenDirectory(Destinationdead);
            writerdelete1.OpenSecurityBySymbol(SecSymbolbol);
            FinalDate4 = int.Parse(todaysDate);
    
            writerdelete1.OpenDirectory(Destinationdead);
            writerdelete1.OpenSecurityBySymbol(SecSymbol);
            writerdelete1.DeleteSecRecords(idate, itodate);
            
            break;
        }
        catch (Exception)
        {
            idate += 60 * 60 * 24; // advance by one day
            continue;
        }
    }
