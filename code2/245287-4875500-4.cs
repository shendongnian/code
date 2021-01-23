    var messageUsers = (
          from pm in dc.PrivateMessages
          where !pm.IsDeletedRecipient && pm.RecipientID == id
          select new PMInbox {
              SenderUsername = (
                    from user in dc.Users
                    where user.UserID == pm.SenderID
                    select user.Username
                  ).SingleOrDefault(),
              PrivateMessageID = pm.PrivateMessageID,
              //...
          }
        ).ToList();
