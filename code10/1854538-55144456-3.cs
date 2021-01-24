    using System;
    using System.Collections.Generic;
    using System.Data;
    using MoreLinq;
    using Oracle.ManagedDataAccess.Client;
    namespace ReadLargeDataset
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                foreach (var batch in GetData<string>("hello world").Batch(50000))
                {
                    ProcessBusinessLogic(batch);
                }
            }
            public static void ProcessBusinessLogic<T>(IEnumerable<T> data)
            {
                //TODO Implement fancy business logic here
            }
            public static IEnumerable<T> GetData<T>(string sql)
            {
                using (var conn = GetConnection())
                {
                    if (ConnectionState.Closed == conn.State) conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sql; //TODO: Make sure you do standard sql injection prevention
                        using (var reader = cmd.ExecuteReader())
                        {
                            //We want to optimize the number of round trips to the DB our reader makes.
                            //Setting the FetchSize this way will make the reader bring back 5000 records
                            //with every trip to the DB
                            reader.FetchSize = reader.RowSize * 5000;
                            while (reader.Read())
                            {
                                var values = new object[reader.FieldCount];
                                reader.GetValues(values);
                                //This assumes that type T has a constructor that takes in an object[]
                                //and the mappings of object[] to properties is done in that constructor
                                yield return (T)Activator.CreateInstance(typeof(T), new object[] { values });
                            }
                        }
                    }
                }
            }
            private static OracleConnection GetConnection()
            {
                return new OracleConnection(new OracleConnectionStringBuilder
                {
                    //TODO: Set other connection string properties
                    ConnectionTimeout = 0
                }.ConnectionString);
            }
        }
    }
