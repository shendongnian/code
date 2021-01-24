    private void Cmb_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_GB1_1.SelectedIndex <=0)
            {
                GB_2.Enabled = false;
            }
            else
            {
                GB_2.Enabled = true;
            }
            
        }
        private void Cmb_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_GB1_2.SelectedIndex <= 0)
            {
                GB_3.Enabled = false;
            }
            else
            {
                GB_3.Enabled = true;
            }
            
