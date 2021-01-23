    var query = from s in db.Singles
                group s by s.ArtistID into sg
                select new
                {
                  ArtistID = sg.Key,
                  SingleID = sg.OrderByDescending(r => r.SingleID).FirstOrDefault().SingleID,
                  Released = sg.OrderByDescending(r => r.SingleID).FirstOrDefault().Released,
                  Title = sg.OrderByDescending(r => r.SingleID).FirstOrDefault().Title,
                }
