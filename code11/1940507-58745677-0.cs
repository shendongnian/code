       public void GetMethod3() {
            DateTime dtFrom = new DateTime(DateTime.Now.Year, 01, 01);
            DateTime dtTo = new DateTime(DateTime.Now.Year, 12, 31);
            Recipient teamMember = oApp.Session.CreateRecipient(email);
            teamMember.Resolve();
            if(teamMember.Resolved)
            { 
               MAPIFolder sharedCalendar = oApp.Session.GetSharedDefaultFolder(teamMember, OlDefaultFolders.olFolderCalendar);
               if(sharedCalendar.DefaultMessageClass != "IPM.Appointment" || teamMember.DisplayType != 0) {
                   return; //Calendar not shared.
               }
               string restrictCriteria = "[Start]<=\"" + dtTo.ToString("g") + "\"" + " AND [End]>=\"" + dtFrom.ToString("g") + "\"";
               Items results = sharedCalendar.Items.Restrict(restrictCriteria);
               foreach(AppointmentItem item in results) {
                  Console.WriteLine(item.Subject + " - " + item.Start + " - " + item.Body + " - " + item.Location);
               }
            }
        }
As you may see the recipient should be resolved against your address book before trying to access a shared calendar. The [Recipient.Resolve][2] method attempts to resolve a `Recipient` object against the Address Book.
  [1]: https://docs.microsoft.com/en-us/office/vba/api/outlook.namespace.getshareddefaultfolder
  [2]: https://docs.microsoft.com/en-us/office/vba/api/outlook.recipient.resolve
