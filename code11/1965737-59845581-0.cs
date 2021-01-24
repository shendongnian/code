   public bool AppointmentFound(string entryID) {
         
         try {
            var query = from AppointmentItem ai in calendarAppointments
                        where ai.EntryID == entryID
                        select ai;
            bRes = query.Any();
         }
         catch(NetOffice.NetOfficeException ex) {
         }
         return bRes;
      }
