    if (BoatNameTextBox.Text == "") {
        MessageBox.Show("Please Input Name", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
    } else {
        (ComboBox cbo, NumericUpDown nud)[] input = new[] {
            (Catch1ComboBox, NumericAmount1),
            (Catch2ComboBox, NumericAmount2),
            (Catch3ComboBox, NumericAmount3),
            (Catch4ComboBox, NumericAmount4)
        };
        if (input.Any(x => x.cbo.SelectedIndex != -1 && x.nud.Value == 0)) {
            MessageBox.Show("Please Input Amount Of Fish Caught", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
