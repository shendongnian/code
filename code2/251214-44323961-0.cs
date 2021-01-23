        private void MasterMail(string MailContents)
        {
            Modules.MessageUpdate(this, ObjApp, EH, 3, 25, "", "", "", 0, 0, 0, 0, "Master Email - MasterMail Called.", "N", MainTxtDict, MessageResourcesTxtDict);
            Outlook.Application OApp = new Outlook.Application();
            //Location of email template to use. Outlook wont include my Signature through this automation so template contains only that.
            string Temp = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + ResourceDetails.DictionaryResources("SigTempEmail", MainTxtDict);
            Outlook.Folder folder = OApp.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderDrafts) as Outlook.Folder;
            //create the email object.
            Outlook.MailItem TestEmail = OApp.CreateItemFromTemplate(Temp, folder) as Outlook.MailItem;
            //Set subject line.
            TestEmail.Subject = "Automation Results";
            //Create Recipients object.
            Outlook.Recipients oRecips = (Outlook.Recipients)TestEmail.Recipients;
            //Set and check email addresses to send to.
            Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add("EmailAddressToSendTo");
            oRecip.Resolve();
            //Set the body of the email. (.HTMLBody for HTML Emails. .Body will preserve "Environment.NewLine")
            TestEmail.Body = MailContents + TestEmail.Body;
            try
            {
                //If outlook is not open, Open it.
                Process[] pName = Process.GetProcessesByName("OUTLOOK.EXE");
                if (pName.Length == 0)
                {
                    System.Diagnostics.Process.Start(@"C:\Program Files\Microsoft Office\root\Office16\OUTLOOK.EXE");
                }
                //Send email
                TestEmail.Send();
                //Update logfile - Success.
                Modules.MessageUpdate(this, ObjApp, EH, 1, 17, "", "", "", 0, 0, 0, 0, "Master Email sent.", "Y", MainTxtDict, MessageResourcesTxtDict);
            }
            catch (Exception E)
            {
                //Update LogFile - Fail.
                Modules.MessageUpdate(this, ObjApp, EH, 5, 4, "", "", "", 0, 0, 0, 0, "Master Email - Error Occurred. System says: " + E.Message, "Y", MainTxtDict, MessageResourcesTxtDict);
            }
            finally
            {
                if (OApp != null)
                {
                    OApp = null;
                }
                if (folder != null)
                {
                    folder = null;
                }
                if (TestEmail != null)
                {
                    TestEmail = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
