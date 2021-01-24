    MailMessageTextPlaceholders = new List<MailMessageTextPlaceholder>
    {
        new MailMessageTextPlaceholder
        {
            PlaceholderName = "status",
            Value = 
               status == LockCard.LockCardStatus.Done
                   ? "Is Done";
                   : status == LockCard.LockCardStatus.Pending 
                      ? "Is in Pending status"
                      : status == LockCard.LockCardStatus.Open 
                          ? "Has been created"
                          : "No status yet!";
        }
    }
