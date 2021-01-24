    public ActionResult InvalidEmails(int UploadId)
    {
            //var emails = db.sp_marketing_getInvalidEmailsByUploadId(UploadId);
            var emailTable = (from mie in db.marketingdbclients_invalidEmails
                              join mdt in db.marketingdbclients_dataTable on mie.ClientId equals mdt.ClientId
                              where mdt.UploadId == 88
                              select new marketingdbclients_invalidEmailsVM
                              {
                                  ClientId = mie.ClientId,
                                  Email1=mie.Email1,
                                  Email2=mie.Email2,
                                  Email3=mie.Email3,
                                  Email4=mie.Email4,
                                  DateStamp=mie.DateStamp
                              });
            return View(emailTable);
        }
    
