        static Guid GetGuidFromDb(object dbValue)
        {
            if (dbValue == null || DBNull.Value.Equals(dbValue))
            {
                return Guid.Empty;
            }
            else
            {
                return (Guid) dbValue;
            }
        
