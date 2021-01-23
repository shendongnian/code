    //Open connection
    string conString = "server=myserver; Uid=myusername; database=myscheme; Pwd=mypwd";
    MySqlConnection con = new MySqlConnection(conString);
    try
    {
        //Set first variable, @START
        string sql = "SET @START = '" + date1 + "'";
        MySqlScript cmd = new MySqlScript(con, sql);
        cmd.Connection.Open();
        cmd.Execute();
        //Set second variable, @END
        sql = "SET @END = '" + date2 + "'";
        cmd = new MySqlScript(con, sql);
        cmd.Execute();
        //Send procedure call
        MySqlDataAdapter MyDA = new MySqlDataAdapter();
        sql = "call MY_DB_PROCEDURE";
        MyDA.SelectCommand = new MySqlCommand(sql, con);
        //From here you can process the DB response as you want
        //For instance, display the results in a datagridview
        DataTable table = new DataTable();
        MyDA.Fill(table);
        BindingSource bSource = new BindingSource();
        bSource.DataSource = table;
        //"dataGridView1" is already placed in the active form
        dataGridView1.DataSource = bSource;
        dataGridView1.Visible = true;
    }
    catch (Exception e)
    {
        //Error handling procedure
    }
    finally
    {
        if (con.State == ConnectionState.Open)
        {
            con.Dispose(); // return connection to the pool
        }
    }
