    private void StationComboBox_1_SelectionChanged(object sender,
        System.Windows.Controls.SelectionChangedEventArgs e)
    {
        UpdateTextFromSelection(stationComboBox_1, serial_1);
    }
    private void UpdateTextFromSelection(ComboBox comboBox, TextBox serialTextBox)
    {
        string constring = "datasource=localhost; username=PC;password=pw;";
        string query = "SELECT serial_Units from db.units where station_Units=@unit;";
        using (var conDataBase = new MySqlConnection(constring)) {
            var cmdDataBase = new MySqlCommand(query, conDataBase);
            cmdDataBase.Parameters.Add("@unit", comboBox.SelectedItem);
            try {
                conDataBase.Open();
                serialTextBox.Text = (string)cmdDataBase.ExecuteScalar();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
