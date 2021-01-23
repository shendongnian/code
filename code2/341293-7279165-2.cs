    using System.Data;
    using System.Data.SqlClient;
    ....
    protected void Page_Load(object sender, EventArgs e)
    {
       string myLabelText = Get_MyLabel;
       if (myLabelText != null)
          MyLabel.Text = myLabelText;
    }
    private void Get_MyLabel(string connStr)
    {
        string myLabelText;
        try
        {
            conn.Open();
            // Returns a single column from the first row of the query
            string myLabelText = cmd.ExecuteScalar().ToString();                
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            if (conn != null && conn.State != ConnectionState.Closed)
                conn.Close()
        }
        return myLabelText;
    }
