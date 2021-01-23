    var messageUsers = (from pm in dc.PrivateMessages
                        where !pm.IsDeletedRecipient && pm.RecipientID == id
                        select new PMInbox {
                            SenderUsername = dc.Users
                                .Where(user=>user.UserID == pm.SenderID)
                                .Select(user=>user.Username)
                                .SingleOrDefault(),
                            PrivateMessageID = pm.PrivateMessageID,
                            //...
                        }).ToList();
