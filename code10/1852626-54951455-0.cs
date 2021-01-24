        private void Enable_disableSTM()
        {
            if (STM_groupBox.Text.IndexOf("INC", StringComparison.OrdinalIgnoreCase) >= 0;)
            {
                STM_radioButton_appel.Enabled = true;
                STM_radioButton_autre.Enabled = true;
                STM_radioButton_resolution.Enabled = true;
                STM_Textbox_SR.Enabled = true;
                STM_textBox_remarque.Enabled = true;
                STM_Dropdown_Sendto.Enabled = true;
                STM_pictureBox_Boutonenvoyer.Enabled = true;
            }
            else
            {
                STM_radioButton_appel.Enabled = false;
                STM_radioButton_autre.Enabled = false;
                STM_radioButton_resolution.Enabled = false;
                STM_Textbox_SR.Enabled = false;
                STM_textBox_remarque.Enabled = false;
                STM_Dropdown_Sendto.Enabled = false;
                STM_pictureBox_Boutonenvoyer.Enabled = false;
            }
        } 
