        void comboBox_Leave(object sender, EventArgs e)
        {
           ComboBox cbo = (sender as ComboBox);
            if (cbo.Text.Length > 0)
            {
                Int32 rowIndex = cbo.FindString(cbo.Text.Trim());
                if (rowIndex != -1)
                {
                    cbo.SelectedIndex = rowIndex;
                }
                else
                {
                    cbo.SelectedIndex = -1;
                }
            }
            else
            {
                cbo.SelectedIndex = -1;
            }
        }
