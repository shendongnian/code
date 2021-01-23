    private void button1_Click_1(object sender, EventArgs e)
    {
        conn.Open();        
        Adaptador.UpdateCommand = "<Your SQL here>"  // I.e., UPDATE [TABLE] SET....
        try
        {
            Adaptador.Update((DataTable)Bsource.DataSource);
        }
        catch (Exception ex)
        {
            // Do something with the exception
        }
    }
