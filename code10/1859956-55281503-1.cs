    MailMessageTextPlaceholders = new List<MailMessageTextPlaceholder>
    {
        new MailMessageTextPlaceholder
        {
            PlaceholderName = "status",
            Value = GetStatusDescription(_lockCard.Status)
        }
    }
    
    string GetStatusDescription(LockCard.LockCardStatus status)
    {
         switch (status)
         {
            case (int)LockCard.LockCardStatus.Done :
                 return "Is Done";
            case (int)LockCard.LockCardStatus.Pending :
                 return "Is in Pending status";
            case (int)LockCard.LockCardStatus.Open :
                  return "Has been created";
            default:
                  return "No status yet!";
        }
    }
