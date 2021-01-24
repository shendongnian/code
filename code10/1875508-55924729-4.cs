    private void StationComboBox_1_SelectionChanged(object sender,
        System.Windows.Controls.SelectionChangedEventArgs e)
    {
        UpdateTextFromSelection(stationComboBox_1, serial_1);
    }
    private void UpdateTextFromSelection(ComboBox comboBox, TextBox serialTextBox)
    {
        string constring = "datasource=localhost; username=PC;password=pw;";
        string query = "SELECT serial_Units from db.units where station_Units=@unit;";
        using (var conn = new MySqlConnection(constring)) {
            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.Add("@unit", comboBox.SelectedItem);
            try {
                conn.Open();
                serialTextBox.Text = (string)cmd.ExecuteScalar();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
