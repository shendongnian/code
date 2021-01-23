    using Microsoft.Office.Interop.Outlook;
    using Microsoft.VisualBasic;
     public void GetAttachments()
    {
	Microsoft.Office.Interop.Outlook.Application myolApp = default(Microsoft.Office.Interop.Outlook.Application);
	Microsoft.Office.Interop.Outlook.NameSpace ns = default(NameSpace);
	MAPIFolder Inbox = default(MAPIFolder);
	object Item = null;
	Attachment Atmt = default(Attachment);
	string FileName = null;
	string subject = null;
	string AttachmentName = null;
	string Body = null;
	string SenderName = null;
	string SenderEmailAddress = null;
	string CreationTime = null;
	int i = 0;
	int j = 0;
	try
	{
		myolApp = (Microsoft.Office.Interop.Outlook.Application)Interaction.CreateObject("Outlook.Application","");
		ns = myolApp.GetNamespace("MAPI");
		ns.Logon("", "", false, true);
		Inbox = ns.Folders["Mailbox - name"].Folders["Inbox"];
		i = 0;
		j = 1;
		//Scan for attachments
		foreach (object Item_loopVariable in Inbox.Items) {
			Item = Item_loopVariable;
			System.Windows.Forms.Application.DoEvents();
            
			if ((Item as MailItem) != null ? ((MailItem)Item).UnRead : false) {
				MessageBox.Show(j.ToString(), "EMail Number");
				subject = ((Microsoft.Office.Interop.Outlook.MailItem)Item).Subject;
				MessageBox.Show(subject, "E-Mail Subject");
				AttachmentName = ((Microsoft.Office.Interop.Outlook.MailItem)Item).Attachments[1].FileName;
				Body = ((Microsoft.Office.Interop.Outlook.MailItem)Item).Body;
				SenderEmailAddress = ((Microsoft.Office.Interop.Outlook.MailItem)Item).SenderEmailAddress;
				SenderName = ((Microsoft.Office.Interop.Outlook.MailItem)Item).SenderName;
				CreationTime = ((Microsoft.Office.Interop.Outlook.MailItem)Item).CreationTime.ToString();
				MessageBox.Show(AttachmentName, "Attachment Name");
				MessageBox.Show(Body, "Body");
				MessageBox.Show(SenderEmailAddress, "From Address");
				MessageBox.Show(SenderName, "From");
				MessageBox.Show(CreationTime, "Created Time");
				j = j + 1;
				if ((SenderEmailAddress.ToLower() == "lch@gmail.com".ToLower())) {
					MessageBox.Show("reading from");
					foreach (Attachment att in ((MailItem)Item).Attachments ) {
                        FileName = "C:\\Email Attachments\\" + att.FileName;
                        att.SaveAsFile(FileName);
						i = i + 1;
                        ((MailItem)Item).UnRead = true;
					}
				}
			}
		}
		//Display summary
		if (i > 0) {
			MessageBox.Show("I found " + i + " attached files." + "\r\n" + "I have saved them into the C:\\Email Attachments folder." + "\r\n" + "\r\n" + "Have a nice day.", "Finished!");
		} else {
			MessageBox.Show("I didn't find any attached files in your mail.", "Finished!");
		}
			//Clear Memory
			Atmt = null;
			Item = null;
			ns = null;
		
	}
	catch (System.Exception ex)
	{
			MessageBox.Show("An unexpected error has occurred." 
           + "\r\n" + "Please note and report the following information."
           + "\r\n" + "Script Name: GetAttachments"
           + "\r\n" + "Error Description: " + ex.Message
           + "\r\n" + "Error StackTrace: " + ex.StackTrace
           , "Error!");
		   	Atmt = null;
			Item = null;
			ns = null;
	}
    }
