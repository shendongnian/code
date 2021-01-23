    public static List<object> GetInbox(Guid id)
        {
            using (Flirt4dateDBDataContext dc = new Flirt4dateDBDataContext())
            {
                List<object> query = (from pm in dc.PrivateMessages
                            join user in dc.Users
                            on pm.Sender equals user.UserID 
                            select new
                            {
                                SenderName = user.Username
                            }).ToList();
                return query;
               
            }
        }
