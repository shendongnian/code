    private void cb_CheckedChanged(Object sender, EventArgs e) {
       string NameSet  = (sender as CheckBox).Name.Split(new char[]{'_'})[1];
       Form.ActiveForm.Controls.Remove("ch_" + NameSet);
       Form.ActiveForm.Controls.Remove("tb1_" + NameSet);
       Form.ActiveForm.Controls.Remove("tb2_" + NameSet);
       Form.ActiveForm.Controls.Remove("tb3_" + NameSet);
       Form.ActiveForm.Controls.Remove("tb4_" + NameSet);
    }
