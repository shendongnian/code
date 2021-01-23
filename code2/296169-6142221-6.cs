        public int GetMessageCountBy_Username(string username, bool sent)
        {
            Expression<Func<Message, bool>> userSelector = x => ((sent ? x.FromUser : x.ToUser).Username.ToLower() == username.ToLower()) && (sent ? !x.SenderDeleted : !x.RecipientDeleted);
            var query = _dataContext.Messages
                .Count(userSelector);
            return query;
        }
