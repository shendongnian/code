        public override Task AddGroupAsync(string connectionId, string groupName)
        {
            if (connectionId == null)
            {
                throw new ArgumentNullException(nameof(connectionId));
            }
            if (groupName == null)
            {
                throw new ArgumentNullException(nameof(groupName));
            }
            var connection = _connections[connectionId];
            if (connection == null)
            {
                return Task.CompletedTask;
            }
            _groups.Add(connection, groupName);
            return Task.CompletedTask;
        }
