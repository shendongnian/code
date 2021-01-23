        /// <summary>
        /// Retrieves the total number of messages for the user.
        /// </summary>
        /// <param name="username">The name of the user.</param>
        /// <param name="sent">True if retrieving the number of messages sent.</param>
        /// <returns>The total number of messages.</returns>
        public int GetMessageCountBy_Username(string username, bool sent)
        {
            var query = _dataContext.Messages
                .Count(UserSelector(username, sent));
            return query;
        }
