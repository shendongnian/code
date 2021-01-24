     var activities = ctx.Activities.Where(a => a.SiteID == propID && a.ActivityTypeName == "Call")
                    .Select(x => new 
                    {                 
                        x.DateTimeEntry,
                        x.Contact.OwnerContact.ParcelDatas.FirstOrDefault(a => a.OwnerContactID == x.Contact.OwnerContact.OOwnerID).Parcel_LetterTracking.LMailDate,
                        x.FAQs.FirstOrDefault(a => a.ActivityID == x.ActivityID).FAQ_Library.FaqNum,
                        x.FAQs.FirstOrDefault(a => a.ActivityID == x.ActivityID).FAQ_Library.Question
                }).AsEnumerable();
