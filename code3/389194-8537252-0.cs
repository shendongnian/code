    public void DeleteLastMessage()
    {
      using (var db = new DemoDataDataContext())
      {
        var lastMessage = (from m in db.Messages
                         orderby m.ID
                         select m)
                    .LastOrDefault();
        db.Messages.Remove(lastMessage);
        db.SaveChanges();
      }
    }
