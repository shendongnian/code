public void BindGridView()
{
    try
    {
        using(OracleConnection conn = new OracleConnection("add your connection details"))
        using(OracleCommand cmd = new OracleCommand("select * from teszt", conn))
        {
            conn.Open();
            using(OracleDataReader reader = cmd.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}
