C#
try
{
    {
        string cmd = "BACKUP DATABASE [" + database + "] TO DISK='" + @"C:\Tools" + "\\" + "Local" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";
        using (SqlCommand command = new SqlCommand(cmd, con))
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("database backup done successfully");
            System.Diagnostics.Process.Start("net", "stop MSSQLSERVER").WaitForExit();
            MessageBox.Show("SQL Server was stopped successfully");
            System.Diagnostics.Process.Start("net", "start MSSQLSERVER").WaitForExit();
            MessageBox.Show("SQL Server was restarted successfully");
        }
    }
}
catch (Exception ex)
{
    MessageBox($"error occurred: {ex.ToString()}");
}
You can catch can display errors in your catch() or alert for server started/stopped as each occurs. That way you won't have to guess what it is, but have a clear message to go off of.
If you want to stop/start a **Service** instead of the process then try using `System.ServiceProcess` eg:
C#
 ServiceController service = new ServiceController("SQL Server (MSSQLSERVER)");
 service.Stop();
 service.Start();
Keep in mind you'll want to run as and admin to get that to work. 
