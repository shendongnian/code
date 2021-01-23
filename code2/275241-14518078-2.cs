            /// <summary>
        /// Returns a new conContractorEntity instance filled with the DataReader's current record data
        /// </summary>
        protected virtual conContractorEntity GetContractorFromReader(IDataReader reader)
        {
            return new conContractorEntity()
            {
                ConId = GetValue<int>(reader["conId"]),
                ConEmail = reader["conEmail"].ToString(),
                ConCopyAdr = GetValue<bool>(reader["conCopyAdr"], true),
                ConCreateTime = GetValue<DateTime>(reader["conCreateTime"])
            };
        }
    // Base methods
            protected T GetValue<T>(object obj)
        {
            if (typeof(DBNull) != obj.GetType())
            {
                return (T)Convert.ChangeType(obj, typeof(T));
            }
            return default(T);
        }
        protected T GetValue<T>(object obj, object defaultValue)
        {
            if (typeof(DBNull) != obj.GetType())
            {
                return (T)Convert.ChangeType(obj, typeof(T));
            }
            return (T)defaultValue;
        }
