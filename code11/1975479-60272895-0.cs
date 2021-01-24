foreach (DataRow row in ds.Tables[0].Rows)
{
   row.SetAdded();
}
after the Fill() call to set the RowState of each row to "Added".
The final working solution is:
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.IO;
namespace DataAdapterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a simple dataset
            DataSet ds = new DataSet();
            var filename = @"C:\Users\willi\Downloads\MasterDataReport2.csv";
            var connString = string.Format(
                @"Provider=Microsoft.Jet.OleDb.4.0; 
                Data Source={0};
                Extended Properties=""Text;
                HDR=YES;
                FMT=Delimited""", 
                Path.GetDirectoryName(filename));
            using (var conn = new OleDbConnection(connString))
            {
                conn.Open();
                var query = "SELECT * FROM [" + Path.GetFileName(filename) + "]";
                using (var adaptr = new OleDbDataAdapter(query,conn))
                {
                    adaptr.Fill(ds);
                }
            }
            // Change the RowState to "Added" for the Update() method
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row.SetAdded();
            }
            // Save in an SQLite file
            string desktopPath =
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string fullPath = desktopPath + "\\class.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + fullPath);
            con.Open();
            // receive the information from the DataSet into the db
            SQLiteCommand cmd = new SQLiteCommand(con);
            SQLiteDataAdapter adaptor = new SQLiteDataAdapter("SELECT * from MasterDataTable", con);
            adaptor.InsertCommand = new SQLiteCommand("INSERT INTO MasterDataTable VALUES (" +
                ":startTime, " +
                ":entryId, " +
                ":entryType, " +
                ":category, " +
                ":class, " +
                ":participants, " +
                ":studioName, " +
                ":routineTitle)",
                con
            );
            adaptor.InsertCommand.Parameters.Add("startTime", DbType.String, 0, "StartTime");
            adaptor.InsertCommand.Parameters.Add("entryId", DbType.Int16, 0, "EntryID");
            adaptor.InsertCommand.Parameters.Add("entryType", DbType.String, 0, "EntryType");
            adaptor.InsertCommand.Parameters.Add("category", DbType.String, 0, "Category");
            adaptor.InsertCommand.Parameters.Add("class", DbType.String, 0, "Class");
            adaptor.InsertCommand.Parameters.Add("participants", DbType.String, 0, "Participants");
            adaptor.InsertCommand.Parameters.Add("studioName", DbType.String, 0, "StudioName");
            adaptor.InsertCommand.Parameters.Add("routineTitle", DbType.String, 0, "Routine Title");
            adaptor.Update(ds);
            //Check database by filling the dataset in the other direction and displaying
            ds = new DataSet();
            adaptor.Fill(ds);
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine("Table {0}", dt.TableName);
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        Console.Write("{0,-18}", dr[dc]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
This code is just a working prototype for a larger project, but it works as expected.
