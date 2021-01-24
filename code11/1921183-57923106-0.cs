    string pquery = "SELECT * FROM controlp";
    NpgsqlConnection conn = new NpgsqlConnection(Utils.ConnectionString);
    conn.Open();
    NpgsqlCommand pcmd = new NpgsqlCommand(pquery, conn);
    NpgsqlDataAdapter pda = new NpgsqlDataAdapter();
    pda.SelectCommand = pcmd;
    DataTable pdt = new DataTable();
    pda.Fill(pdt);
    pDGV.DataSource = pdt;
    for (int i = 0; i < pdt.Rows.Count; i++)
        {
            comComboBox.Items.Add(pdt.Rows[i].ItemArray[0].ToString());
            priComboBox.Items.Add(pdt.Rows[i].ItemArray[1].ToString());
            notComboBox.Items.Add(pdt.Rows[i].ItemArray[2].ToString());
        }
    conn.Close();
    private void comComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            priComboBox.SelectedIndex = notComboBox.SelectedIndex = comComboBox.SelectedIndex;
            notTextBox.Text = notComboBox.Text;
            priTextBox.Text = priComboBox.Text;
        }
