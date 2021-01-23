    private void flowLayoutPanel1_ControlRemoved(object sender, ControlEventArgs e)
            {
                if (flowLayoutPanel1.Controls.Count > 0)
                {
                    customtoolwarning.Visible = true;
                }
                else
                {
                    customtoolwarning.Visible = false;
                }
            }
