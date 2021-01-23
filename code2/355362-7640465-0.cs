    public class MyPocoMapper : IResultSetMapper<MyPoco>
    {
        public IEnumerable<MyPoco> MapSet ( IDataReader reader )
        {
            using(reader) // Dispose the reader when we're done
            {
                while (reader.Read())
                {
                    yield return new MyPoco()
                    {
                        MyProperty1 = reader.GetString(
                            reader.GetOrdinal("MyPropertyX")),
                        MyProperty2 = reader.GetString(1)
                    };
                }
            }
        }
    }
