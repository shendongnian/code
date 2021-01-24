private void BtnGetNum_Click(object sender, EventArgs e)
{
    string dayName = txtDayName.Text;
    int dayIndex;
    dayIndex = Array.FindIndex(days, a => a.Equals(dayName, StringComparison.CurrentCultureIgnoreCase));
    lblNumOut.Text = dayIndex.ToString();
}
private void BtnGetDay_Click(object sender, EventArgs e)
{
    int dayNumber;
    if (!int.TryParse(txtDayNum.Text, out dayNumber) || dayNumber < 1 || dayNumber > 7)
    {
        MessageBox.Show("Must be a valid number from 1 to 7.");
        return;
    }
    lblNameOut.Text = days[dayNumber - 1];
}
Good luck
