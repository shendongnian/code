    using System;
    using System.Data;
    using System.Data.SQLite;
    using System.Diagnostics;
    using System.IO;
...
    using (var myconnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;PRAGMA journal_mode=WAL;"))
    using (var fileLineReader = new StreamReader(newFilePath))
    {
        myconnection.Open();
        var cmd = myconnection.CreateCommand();
        cmd.CommandText = "drop table if exists myfile";
        cmd.ExecuteNonQuery();
        cmd.CommandText = "create table myfile (value varchar(2147483647))";
        cmd.ExecuteNonQuery();
        using (var transaction = myconnection.BeginTransaction())
        {
            cmd.CommandText = "insert into myfile (value) values (@value)";
            string line;
            while ((line = fileLineReader.ReadLine()) != null)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@value", line);
                cmd.ExecuteNonQuery();
            }
            transaction.Commit();
        }
        cmd.CommandText = "select value,count(*) as count from myfile group by value";
        using (TextWriter writer = File.CreateText(aggregateFilePathBase))
        {
            foreach (IDataRecord record in cmd.ExecuteReader())
            {
                writer.WriteLine(record["value"] + "," + record["count"]);
            }
        }
    }
