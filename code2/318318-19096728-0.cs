        // In Global Properties
        public static Outlook.Application olook = new Outlook.Application();        // Outlook Application Object.
 
        // In Method 
        Outlook.AppointmentItem olookAppointment = (Outlook.AppointmentItem)olook.CreateItem(Outlook.OlItemType.olAppointmentItem);
