        using Microsoft.Office.Interop.Outlook;
        
        Application outlookApplication = new Application();
        MAPIFolder customer_folder = GetMyFolder(path, outlookApplication.Session.Folders);  //function to get your folder
        AppointmentItem apt = (AppointmentItem)customer_folder.Items.Add(OlItemType.olAppointmentItem);
        // set parameters for 'apt', like body, subject etc.
        // ...
        apt.Save();
