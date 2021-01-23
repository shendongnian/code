    public static T GetValueOrDefault<T>(SqlDataReader dataReader, System.Enum columnIndex)
    {
        int index = Convert.ToInt32(columnIndex);
        return !dataReader.IsDBNull(index) ? (T)dataReader.GetValue(index) : default(T);
    }
