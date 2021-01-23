        /// <summary>
        /// Retrieves a list of messages from the data context for a user.
        /// </summary>
        /// <param name="username">The name of the user.</param>
        /// <param name="page">The page number.</param>
        /// <param name="itemsPerPage">The number of items to display per page.</param>
        /// <returns>An enumerable list of messages.</returns>
        public IEnumerable<Message> GetMessagesBy_Username(string username, int page, int itemsPerPage, bool sent)
        {
            var query = _dataContext.Messages
                .Where(UserSelector(username, sent))
                .OrderByDescending(x => x.SentDate)
                .Skip(itemsPerPage * (page - 1))
                .Take(itemsPerPage);
            return query;
        }
