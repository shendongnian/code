    protected void Page_Load(object sender, EventArgs e)
    {
    if(!IsPostBack)
    {
    string connectionString = "data source=localhost ;initial catalog=archiwizacjatvs;user id=user;password=password";
              MySqlConnection conn = new MySqlConnection(connectionString);
              try
              {
                  conn.Open();
                  MySqlDataAdapter dadapter = new MySqlDataAdapter("select * from archiwum order by nazwa_dysku DESC", conn);
                  DataTable tablica = new DataTable();
                  dadapter.Fill(tablica);
                  DataTableReader datatablereader = tablica.CreateDataReader();
                  DataRow row = tablica.Rows[0];
                  for (int i = 1; i <= Convert.ToInt64(row[1]); i++)
                    {
                    DropDownList2.Items.Add(i.ToString());
                    }
                  conn.Close();
              }
              catch (Exception ex)
                {
                    TextBox2.Text = ex.ToString();
                }
}
