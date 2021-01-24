private void BtnGetNum_Click(object sender, EventArgs e)
{
    string dayName = txtDayName.Text;
    int dayIndex;
    //To find the index of the day ignoring the case, so the input can be monday, Monday, mOnDaY...etc.
    dayIndex = Array.FindIndex(days, a => a.Equals(dayName, StringComparison.CurrentCultureIgnoreCase));
    //Check if the input is a valid day name:
    if(dayIndex == -1)
    {
        MessageBox.Show("Enter correct day name.");
        return;
    }
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
    //0-based index. When the input say = 3, that means the value position in the array is 3 - 1 = 2.
    lblNameOut.Text = days[dayNumber - 1];
}
Good luck
