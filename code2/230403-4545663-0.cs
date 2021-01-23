    public void Adddatasource()
    {
    SqlCeConnection con = new 
    
        SqlCeConnection("Data Source=|DataDirectory|\\Master.sdf");
    
        try
        {
            con.Open();
    
            MessageBox.Show("Database Connection Established");
        }
        catch (Exception)
        {
            MessageBox.Show("Database Connection Failed");
            throw;
        }
    
    }
