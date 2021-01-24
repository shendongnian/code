    private void Enb_Dis_GB()
        {
            if (Cmb_GB4_1.SelectedIndex > 0 && Cmb_GB4_2.SelectedIndex > 0 && Cmb_GB4_3.SelectedIndex > 0)
            {
                GB_2.Enabled = true;
                GB_3.Enabled = true;
            }
            else
            {
                GB_2.Enabled = false;
                GB_3.Enabled = false;
            }
        }
