    var sulist1 = newlist.Where(c => c.StatusID == EmergencyCV.ID)
                         .Select(c => {
                                         c.color = "Red";
                                         return c;
                                      });
