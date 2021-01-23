        static Guid? GetGuidFromDb(object dbValue)
        {
            if (dbValue == null || DBNull.Value.Equals(dbValue))
            {
                return null;
            }
            else
            {
                return (Guid) dbValue;
            }
        }
