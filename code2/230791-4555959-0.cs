    public static void AddCommandParameter(SqlCommand myCommand)
    {
        myCommand.Parameters.AddWithValue(
            "@AgeIndex",
            (AgeItem.AgeIndex== null) ? DBNull.Value : AgeItem.AgeIndex);
    }
