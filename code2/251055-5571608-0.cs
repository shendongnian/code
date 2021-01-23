    public static void DoStuff()
    {
        SqlCeCommand cmd = new SqlCeCommand();
        SqlCeResultSet myResultSet = cmd.ExecuteResultSet(ResultSetOptions.None);
        var reader = myResultSet.Read();
        bool found = myResultSet.Seek(DbSeekOptions.After);
        if (found)
        {
            myResultSet.Read();
            CommonMethodToFillRowData(myResultSet);
            myResultSet.Update();
        }
        else 
        {
            SqlCeUpdatableRecord myRec = myResultSet.CreateRecord();
            CommonMethodToFillRowData(myRec);
            myResultSet.Insert(myRec);
        }
    }
    // All the messy Type-wrangling is hidden behind the scenes
    public static void CommonMethodToFillRowData(this IDataRecord RowToFill)
    {
        RowToFill.SetInt32(1, 42);
        RowToFill.SetString(2, "Foo");
        // etc...
    }
    // Since SetInt32 seems to do the same thing in either inherited Type
    public static void SetInt32(this IDataRecord RowToFill, int Ordinal, int Value)
    {
        Type rowType = RowToFill.GetType();
        if (rowType == typeof(SqlCeResultSet))
            ((SqlCeResultSet)RowToFill).SetInt32(Ordinal, Value);
        else if (rowType == typeof(SqlCeUpdatableRecord))
            ((SqlCeUpdatableRecord)RowToFill).SetInt32(Ordinal, Value);
        else
            throw new ArgumentException("Method does not know what to do with Type " + rowType.ToString());
    }
    // Since SetString seems to do the same thing in either inherited Type
    public static void SetString(this IDataRecord RowToFill, int Ordinal, string Value)
    {
        Type rowType = RowToFill.GetType();
        if (rowType == typeof(SqlCeResultSet))
            ((SqlCeResultSet)RowToFill).SetString(Ordinal, Value);
        else if (rowType == typeof(SqlCeUpdatableRecord))
            ((SqlCeUpdatableRecord)RowToFill).SetString(Ordinal, Value);
        else
            throw new ArgumentException("Method does not know what to do with Type " + rowType.ToString());
    }
