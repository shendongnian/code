    protected void Page_Load(object sender, EventArgs e)
    {
        DemoAppointmentsInRange();
    }
    private void DemoAppointmentsInRange()
    {
        Application a = new Application();
        Microsoft.Office.Interop.Outlook.Folder calFolder = a.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar) as Microsoft.Office.Interop.Outlook.Folder;
        DateTime start = DateTime.Now;
        DateTime end = start.AddDays(5);
        Microsoft.Office.Interop.Outlook.Items rangeAppts = GetAppointmentsInRange(calFolder, start, end);
        if (rangeAppts != null)
        {
            foreach (Microsoft.Office.Interop.Outlook.AppointmentItem appt in rangeAppts)
            {
               Response.Write("Subject: " + appt.Subject + " "+" Start: "+appt.Start.ToString()+" "+"End:"+appt.End.ToString()+"<br/>");
            }
        }
    }
    private Microsoft.Office.Interop.Outlook.Items GetAppointmentsInRange(
    Microsoft.Office.Interop.Outlook.Folder folder, DateTime startTime, DateTime endTime)
    {
        string filter = "[Start] >= '"+ startTime.ToString("g")+ "' AND [End] <= '"  + endTime.ToString("g") + "'";
        //Response.Write(filter);
        try
        {
            Microsoft.Office.Interop.Outlook.Items calItems = folder.Items;
            calItems.IncludeRecurrences = true;
            calItems.Sort("[Start]", Type.Missing);
            Microsoft.Office.Interop.Outlook.Items restrictItems = calItems.Restrict(filter);
            if (restrictItems.Count > 0)
            {
                return restrictItems;
            }
            else
            {
                return null;
            }
        }
        catch
        {
            return null;
        }
    }
}
