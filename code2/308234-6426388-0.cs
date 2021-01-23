    private void CheckOccurrenceExample()
    {
        Outlook.AppointmentItem appt = Application.Session.
            GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).
            Items.Find(
            "[Subject]='Recurring Appointment DaysOfWeekMask Example'")
            as Outlook.AppointmentItem;
        if (appt != null)
        {
            try
            {
                Outlook.RecurrencePattern pattern =
                    appt.GetRecurrencePattern();
                Outlook.AppointmentItem singleAppt =
                    pattern.GetOccurrence(DateTime.Parse(
                    "7/21/2006 2:00 PM"))
                    as Outlook.AppointmentItem;
                if (singleAppt != null)
                {
                    Debug.WriteLine("7/21/2006 2:00 PM occurrence found.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
