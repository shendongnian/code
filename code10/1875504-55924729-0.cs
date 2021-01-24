    private void StationComboBox_1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        UpdateTextFromSelection(stationComboBox_1, serial_1);
    }
    private void UpdateTextFromSelection(ComboBox comboBox, TextBox serialTextBox)
    {
        string constring = "datasource=localhost; username=PC;password=pw;";
        string query = "SELECT * from db.units where station_Units='" + comboBox.SelectedItem + "';";
        SqlConnection conDataBase = new MySqlConnection(constring);
        MySqlCommand cmdDataBase = new MySqlCommand(query, conDataBase);
        MySqlDataReader myReader;
        try {
            conDataBase.Open();
            myReader = cmdDataBase.ExecuteReader();
            while (myReader.Read()) {
                string serial = myReader.GetString("serial_Units");
                serialTextBox.Text = serial;
            }
        } catch (Exception ex) {
            MessageBox.Show(ex.Message);
        }
    }
