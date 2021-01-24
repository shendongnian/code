    SqlTransaction tran;
        try
        {
                DBCon.Open();
                tran = DBCon.BeginTransaction();
                DBReader = DBCommand.ExecuteReader();
                DBReader2 = DbCommand2.ExecuteNonQuery();
                MessageBox.Show("New transaction record added to the system.", "Library System", MessageBoxButtons.OK);
                tran.Commit();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
