    public void SavingMyData()
    {
        SqlCeResultSet resultSet = cmd.ExecuteResultSet(Options...etc);
        SqlCeWrapper wrapper = new SqlCeWrapper(resultSet);
        wrapper.SetInt32(0, pkValue, true); // Primary Key = true
        wrapper.SetString(1, "value for col 1");
        wrapper.SetString(2, "value for col 2");
        wrapper.SetString(100, "value for col 100");
        wrapper.Commit();
    }
    ...
    public class SqlCeWrapper
    {
        private readonly bool _found;
        private readonly SqlCeResultSet _resultSet;
        private readonly SqlCeUpdatableRecord _newRecord;
        public SqlCeWrapper(SqlCeResultSet resultSet)
        {
            _resultSet = resultSet;
            _found = resultSet.Seek();
            if (_found)
                resultSet.Read();
            else
                _newRecord = resultSet.CreateRecord();
        }
        public void SetInt32(int ordinal, int value, bool isPrimary = false)
        {
            if (_found && !isPrimary)
                _resultSet.SetInt32(ordinal, value);
            else if (!_found)
                _newRecord.SetInt32(ordinal, value);
        }
        public void SetString(int ordinal, string value, bool isPrimary = false)
        {
            if (_found && !isPrimary)
                 _resultSet.SetString(ordinal, value);
            else if (!_found)
                _newRecord.SetString(ordinal, value);
        }
        public void Commit()
        {
            if (_found)
                _resultSet.Update();
            else
                _resultSet.Insert(_newRecord);
        }
    }
