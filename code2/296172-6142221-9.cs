        /// <summary>
        /// Builds an expression to be reused in a LINQ query.
        /// </summary>
        /// <param name="username">The name of the user.</param>
        /// <param name="sent">True if retrieving sent messages.</param>
        /// <returns>An expression to be used in a LINQ query.</returns>
        private Expression<Func<Message, bool>> UserSelector(string username, bool sent)
        {
            return x => ((sent ? x.FromUser : x.ToUser).Username.ToLower() == username.ToLower()) && (sent ? !x.SenderDeleted : !x.RecipientDeleted);
        }
