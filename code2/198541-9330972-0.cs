        using Microsoft.Office.Interop.Outlook;
        MAPIFolder customer_folder = GetMyFolder(Application.Session.Folders);  //function to get your folder
        AppointmentItem apt = (AppointmentItem)customer_folder.Items.Add(OlItemType.olAppointmentItem);
        // set parameters for 'apt', like body, subject etc.
        // ...
        apt.Save();
