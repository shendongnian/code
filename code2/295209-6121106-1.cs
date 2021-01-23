    public int GetMessageCountBy_Username(string username, bool sent)
     {
         Func<Message, string> userSelector = m => sent ? m.Sender : m.Recipient;
         var query =
         _dataContext.Messages.AsQueryable()
         .Where(x => userSelector(x).ToLower() == username.ToLower());
         return query.Count();
     } 
