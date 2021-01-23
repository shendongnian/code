        protected void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (RepeaterItem ri in Repeater.Items)
            {
                foreach (Control c in ri.Controls)
                {
                    if (typeof(CheckBox) == c.GetType())
                    {
                        CheckBox checkBox = (CheckBox)c;
                        checkBox.Checked = true;
                    }
                }
            }
        }
