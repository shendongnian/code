    var timeStamps = new List<Tuple<DateTime, int>>();
    foreach(Invitation item in MailMessageController.GetInvitations())
    {
      if (SendMessage(item)) // <<-- bool if message was sent successfully
      {
         timeStamps.Add(new Tuple<DateTime, int>(DateTime.Now, item.ID);
      }
    }
    UpdateTimeStamps(timeStamps);
