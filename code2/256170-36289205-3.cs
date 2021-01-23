    private void button Click
    {
        MySqlConnection mcon = new MySqlConnection("Yourconnection");
        MySqlDataAdapter adapter;
        DataTable table = new DataTable();
        adapter = new MySqlDataAdapter("Select * From database.table where Username = '" + textbox1.Text + "' and password = '" + textbox2.Text +  "'", mcon);
        adapter.Fill(table);
        if (table.Rows.Count <= 0)
        {
            //message something
        }
        else
        {
            //show main form
        }
    }
