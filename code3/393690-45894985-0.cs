     Outlook.Inspector inspector = Globals.ThisAddIn.Application.ActiveInspector();
                if (inspector != null)
                {
                    Outlook.MailItem  mi = inspector.CurrentItem as Outlook.MailItem;
                  //Then identify whether email sender is exchange user or normal user
                   string senderEmail=null;
                   if (mi.SenderEmailType == "EX")
                    {
                    senderEmail = mi.Sender.GetExchangeUser().PrimarySmtpAddress;                    
                     }
                  else
                    {
                     senderEmail=mi.SenderEmailAddress;
                    }
                 }
