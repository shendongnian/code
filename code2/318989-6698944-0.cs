    protected void getAppTerm()
    {
        string CommandText = "select term from Terms";
        OdbcConnection myConnection = dbconnect();
        OdbcCommand myCommand = new OdbcCommand(CommandText, myConnection);
        try
        {
            myConnection.Open();
            OdbcDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                // Currently, you're overwriting the variable "y" on every iteration
                // and then just comparing the last item.text to status.
                var status = reader.GetString(0);
                if (!ddlApplicationTerm.Items.Contains(status)
                    ddlApplicationTerm.Items.Add(status);
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
        }
        finally
        {
            myConnection.Close();
        }
    }
