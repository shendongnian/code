    object item = Application.Session.GetItemFromID(newItem, Type.Missing);
    Outlook.MailItem mailItem = item as Outlook.MailItem;
    if (mailItem != null)
    {
        ...
    }
    else
    {
        Outlook.MeetingItem meetingItem = item as Outlook.MeetingItem;
        if (meetingItem != null)
        {
            ...
        }   
    }
