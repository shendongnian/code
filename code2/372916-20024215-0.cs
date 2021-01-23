    private void timer_Flashing_Tick(object sender, EventArgs e)
        {
            if (checkBox_Refresh.Checked)
            {
                if (checkBox_Refresh.FlatAppearance.CheckedBackColor == Color.Red)
                {
                    checkBox_Refresh.FlatAppearance.CheckedBackColor = Color.Transparent;
                }
                else
                {
                    checkBox_Refresh.FlatAppearance.CheckedBackColor = Color.Red;
                }
            }
        }
