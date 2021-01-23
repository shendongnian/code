    List<object> query = (from pm in dc.PrivateMessages
                        join user in dc.Users
                        on pm.Sender equals user.UserID 
                        select new
                        {
                            SenderName = user.Username
                        }).ToList();
