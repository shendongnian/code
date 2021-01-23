    string large = "";
    large = btime[0];
    IFormatProvider culture = System.Threading.Thread.CurrentThread.CurrentCulture;
    // This Code will convert the System Format in Thread, Not the Actual Format 
    // of The System
    CultureInfo ciNewFormat = new CultureInfo(CultureInfo.CurrentCulture.ToString());
    ciNewFormat.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
    System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat;
    for (int i = 0; i < TimeBackupCounter; i++)
    {
        if (DateTime.Compare(DateTime.Parse(btime[i]),DateTime.Parse(large)) > 0)
        {
            large = btime[i];
        }
    }
