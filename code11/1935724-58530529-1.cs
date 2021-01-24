    if ((!Catch1ComboBox.isSelected() && NumericAmount1.IsZero()) ||
             (!Catch2ComboBox.isSelected() && NumericAmount2.IsZero()) ||
             (!Catch3ComboBox.isSelected()  && NumericAmount3.IsZero()) ||
             (!Catch4ComboBox.isSelected() && NumericAmount4.IsZero())
    {
        MessageBox.Show("Please Input Amount Of Fish Caught", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
