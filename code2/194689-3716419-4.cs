    namespace Demos.StackOverflow.ExcelUpdate
    {
        using System;
        using System.Collections.ObjectModel;
        using System.Data.OleDb;
        class Program
        {
            static void Main(string[] args)
            {
                // -> Change the following name of the file to use.
                string fullPath = @"C:\Users\Arsene\Desktop\Book1.xlsx";
                string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0'", fullPath);
                Collection<Tuple<string, int>> dataToPut = new Collection<Tuple<string, int>>();
                dataToPut.Add(new Tuple<string, int>("Some name", 34));
                dataToPut.Add(new Tuple<string, int>("Other name here", 41));
                dataToPut.Add(new Tuple<string, int>("Last one", 36));
                using (OleDbConnection oleConnection = new OleDbConnection(connectionString))
                {
                    oleConnection.Open();
                
                    using (OleDbCommand createTable = new OleDbCommand("create table Data1 (Name char(10), Age char(10))", oleConnection))
                    {
                        createTable.ExecuteNonQuery();
                    }
                    foreach (var t in dataToPut)
                    {
                        using (OleDbCommand addItem = new OleDbCommand("insert into Data1 values (@name, @age)", oleConnection))
                        {
                            addItem.Parameters.AddWithValue("@name", t.Item1);
                            addItem.Parameters.AddWithValue("@age", t.Item2);
                            addItem.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
