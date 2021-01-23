        private void Form1_Load(object sender, EventArgs e) {
            chkBox1.CheckedChanged += chkBox_CheckedChanged;
            chkBox2.CheckedChanged += chkBox_CheckedChanged;
            chkBox3.CheckedChanged += chkBox_CheckedChanged;
            chkBox4.CheckedChanged += chkBox_CheckedChanged;
        }
        private void chkBox_CheckedChanged(object sender, EventArgs e) {
            var chkBox = ((CheckBox)sender);
            var controlSet = chkBox.Name.Substring(6,1);
            var txtName = "txtBox" + controlSet;
            foreach (var txtBox in Controls.Cast<object>().Where(ctl => ((Control)ctl).Name == txtName).Select(ctl => ((TextBox)ctl))) {
                if (chkBox.Checked) {
                    txtBox.Enabled = true;
                    txtBox.Focus();
                }
                else {
                    //The checkbox stole the focuse when it was clicked, so no need to change.
                    txtBox.Enabled = false;
                }
            }
        }
