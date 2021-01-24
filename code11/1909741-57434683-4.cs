    private void GB_1_TEXT_CHANGER()
        {
         if(Cmb_GB4_1.SelectedIndex > 0 && Cmb_GB4_2.SelectedIndex > 0 && Cmb_GB4_3.SelectedIndex > 0)
            {
                Cmb_GB1_1.Text = "Enabled";
                Cmb_GB1_2.Text = "Enabled";
            }
            else
            {
                Cmb_GB1_1.Text = "Disabled";
                Cmb_GB1_2.Text = "Disabled";
            }
        }
