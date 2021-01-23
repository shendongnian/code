     foreach (Control item in (groupBox1 as Control).Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is ComboBox)
                {
                    (item as ComboBox).SelectedIndex = -1;
                    (item as ComboBox).Text = "";
                }
            }
