    /// <summary>
    /// Repository defines simple class with standard methods
    /// to accept and operate on any type.
    /// </summary>
    public class Repository
    {
        private ISession _session;
        public ISession Session
        {
            get { return _session; }
        }
        
        /// <summary>
        /// Save an entity.
        /// </summary>
        public void Save<T>(T entity)
        {
            Reconnect(_session);
            try
            {
                _session.Save(entity);
            }
            finally
            {
                Disconnect(_session);
            }
        }
        /// <summary>
        /// Update an entity
        /// </summary>
        public void Update<T>(T entity)
        {
            Reconnect(_session);
            try
            {
                _session.Update(entity);
            }
            finally
            {
                Disconnect(_session);
            }
        }
        /// <summary>
        /// Delete an entity
        /// </summary>
        public void Delete<T>(T entity)
        {
            Reconnect(_session);
            try
            {
                _session.Delete(entity);
            }
            finally
            {
                Disconnect(_session);
            }
        }
        /// <summary>
        /// Retrieve an entity
        /// </summary>
        public T GetById<T>(Guid id)
        {
            Reconnect(_session);
            try
            {
                return _session.Get<T>(id);
            }
            finally
            {
                Disconnect(_session);
            }
        }
        /// <summary>
        /// Method for flushing the session.
        /// </summary>
        public void Flush()
        {
            Reconnect(_session);
            try
            {
                _session.Flush();
                _session.Clear();
            }
            finally
            {
                Disconnect(_session);
            }
        }
        /// <summary>
        /// Reconnect to the session. Accept parameter so we can use anywhere.
        /// </summary>
        public void Reconnect(ISession session)
        {
            if (!session.IsConnected)
            {
                session.Reconnect();
            }
        }
        /// <summary>
        /// Disconnect from the session.  Accept parameter so we can use anywhere.
        /// </summary>
        public void Disconnect(ISession session)
        {
            if (session.IsConnected)
            {
                session.Disconnect();
            }
        }
        public Repository(ISession session)
        {
            _session = session;
        }
    }
}
