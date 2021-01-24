    private void AttachDatabaseToInstance()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=" + DBServerTextBox.Text + @";Initial Catalog=master;;Integrated Security=True;Connect Timeout=30;User ID=dbadmin;Password=dbadmin";
            ServerConnection serverconn = new ServerConnection(con);
            Server s = new Server(serverconn);
            try
            {
                con.Close();
                InstallStatusLabel.Text = "Existing connections closed";
                InstallStatusLabel.Refresh();
                System.Threading.Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {
                s.DetachDatabase("mydatabase", true);
                InstallStatusLabel.Text = "Detaching any existing mydatabase database";
                InstallStatusLabel.Refresh();
                System.Threading.Thread.Sleep(3000);
            }
            catch
            {
                MessageBox.Show("Could not find attached database");
            }
            try
            {
                s.AttachDatabase("mydatabase", new System.Collections.Specialized.StringCollection { DBDataTextBox.Text + @"\mydatabase.mdf", DBDataTextBox.Text + @"\mydatabase_log.ldf" }, AttachOptions.None);
                InstallStatusLabel.Text = "Attached mydatabase database";
                InstallStatusLabel.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
