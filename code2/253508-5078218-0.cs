    override int GetHashCode()
    {
        if (ID != null)
            return ID.GetHashCode();
        return DBNull.Value.GetHashCode();
    }
