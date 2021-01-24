else if ((Catch1ComboBox.SelectedIndex != -1 && NumericAmount1.Value == 0) ||
         (Catch2ComboBox.SelectedIndex != -1 && NumericAmount2.Value == 0) ||
         (Catch3ComboBox.SelectedIndex != -1 && NumericAmount3.Value == 0) ||
         (Catch4ComboBox.SelectedIndex != -1 && NumericAmount4.Value == 0)
{
    MessageBox.Show("Please Input Amount Of Fish Caught", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
*Edit:* Which, I now see you added to your question....
I wouldn't bother with loops or anything unless you had a lot more of these. If there really are only 4, then I would leave it be.
