    public int GetMessageCountBy_Username(string username, bool sent)
     {
         Func<Message,User> userSelector = sent ? m => m.Sender : m => m.Recipient;
         var query =
         _dataContext.Messages.AsQueryable()
         .Where(x => userSelector(x).ToLower() == username.ToLower());
         return query.Count();
     } 
