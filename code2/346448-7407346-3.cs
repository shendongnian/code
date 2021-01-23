    // define a select query
    SelectQuery query =
        new SelectQuery(@"SELECT LastBootUpTime FROM Win32_OperatingSystem
           WHERE Primary='true'");
       
    // create a new management object searcher and pass it
    // the select query
    ManagementObjectSearcher searcher =
        new ManagementObjectSearcher(query);
     
    // get the datetime value and set the local boot
    // time variable to contain that value
    foreach(ManagementObject mo in searcher.Get())
    {
        dtBootTime =
            ManagementDateTimeConverter.ToDateTime(
                mo.Properties["LastBootUpTime"].Value.ToString());
     
        // display the start time and date
        txtDate.Text = dtBootTime.ToLongDateString();
        txtTime.Text = dtBootTime.ToLongTimeString();
    }
