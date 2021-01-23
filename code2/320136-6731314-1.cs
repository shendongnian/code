        protected void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chb = (CheckBox)sender;
            if (chb.Checked)
            {
                //checkbox is checked
                //chb.ID gets the ID of the sender (i.e. checkbox1, checkbox2, etc)
                //write to file
            }
        }
