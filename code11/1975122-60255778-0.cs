if (alreadyIsActive)
  operationCancel();
Also make sure you aren't calling multiple instances of it's self like  – vasily.sib said which can be done like:
 private void metroChecker1_CheckedChanged(object sender, bool isChecked)
    {
        InfoOverLay f = new InfoOverLay();
        if (metroChecker1.Checked == true)
        {
            f.Show();
        }
        if (metroChecker1.Checked == false)
        {
            f.Hide();
        }
Have a good day!
