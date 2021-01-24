        public T GetByID<T>(Int32 ID)
        {
            try
            {
                if (ID == 0)
                    throw (new ArgumentNullException("ID cannot be 0"));
                return _db.SingleOrDefaultById<T>(ID);
            }
            catch { throw; }
        }
