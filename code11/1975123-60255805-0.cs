    private InfoOverLay f = new InfoOverLay(); 
    private void metroChecker1_CheckedChanged(object sender, bool isChecked)
    {
        if (metroChecker1.Checked == true)
        {
             f.Show();
        }
        if (metroChecker1.Checked == false)
        {
            f.Hide();
        }
    }
