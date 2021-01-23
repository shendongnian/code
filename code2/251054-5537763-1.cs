    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlServerCe;
    using System.Collections;
    using System.Data;
    
    namespace SqlCeRecord_Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Arguments for update
                int lookFor = 1;
                string value = "AC/DC";
    
                // Arguments for insert
                lookFor = Int16.MaxValue;
                value = "joedotnet";
    
                using (SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\xeej\Downloads\ChinookPart2\Chinook.sdf"))
                {
                    conn.Open();
    
                    using (SqlCeCommand cmd = new SqlCeCommand("Artist"))
                    {
                        SqlCeUpdatableRecord myRec = null;
                        cmd.Connection = conn;
                        cmd.CommandType = System.Data.CommandType.TableDirect;
                        cmd.IndexName = "PK_Artist";
                        SqlCeResultSet myResultSet = cmd.ExecuteResultSet(ResultSetOptions.Updatable | ResultSetOptions.Scrollable);
                        bool found = myResultSet.Seek(DbSeekOptions.FirstEqual, new object[] { lookFor });
    
                        if (found)
                        {
                            myResultSet.Read();
                        }
                        else
                        {
                            myRec = myResultSet.CreateRecord();
                        }
                        foreach (KeyValuePair<int, object> item in CommonMethodToFillRowData(value))
                        {
                            if (found)
                            {
                                myResultSet.SetValue(item.Key, item.Value);
                            }
                            else
                            {
                                myRec.SetValue(item.Key, item.Value);
                            }
                        }
                        if (found)
                        {
                            myResultSet.Update();
                        }
                        else
                        {
                            myResultSet.Insert(myRec);
                        }
                    }
                }
            }
    
            private static Dictionary<int, object> CommonMethodToFillRowData(string value1) //TODO add more values
            {
                var dict = new Dictionary<int, object>();
                dict.Add(1, value1);
                return dict;
            } 
        }
    }
