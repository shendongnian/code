    public void DropMyDatabase()
        {
            var Your_DB_To_Drop_Name = "YourDB";
            var Your_Connection_String_Here = "SERVER=MyServer;Integrated Security=True";
            var Conn = new SqlConnection(Your_Connection_String_Here);
            var AlterStr = "ALTER DATABASE " + Your_DB_To_Drop_Name + " SET OFFLINE WITH ROLLBACK IMMEDIATE";
            var AlterCmd = new SqlCommand(AlterStr, Conn);
            var DropStr = "DROP DATABASE " + Your_DB_To_Drop_Name;
            var DropCmd = new SqlCommand(DropStr, Conn);
            try
            {
                Conn.Open();
                AlterCmd.ExecuteNonQuery();
                DropCmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch(Exception ex)
            {
                if((Conn.State == ConnectionState.Open))
                {
                    Conn.Close();
                }
                Trace.WriteLine("Failed... Sorry!" + Environment.NewLine + ex.Message);
            }
        }
