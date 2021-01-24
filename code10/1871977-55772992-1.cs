    double total = 0;
    try
    {
        foreach (GroupBox ctrl in this.Controls.OfType<GroupBox>()) //We get all of groupboxes that is in our form (We want the checkboxes which are only in a groupbox.Not all of the checkboxes in the form.)
        {
            foreach (CheckBox c in ctrl.Controls.OfType<CheckBox>()) //We get all of checkboxes which are in a groupbox.One by one.
            {
                if (c.Checked == true)
                {
                    total += Convert.ToDouble(c.Tag);
                }
            }
        }
        tbComplementPrice.Text = string.Format("{0:F2}", total);
    }
    catch
    {
        MessageBox.Show("Error calculating the complement price", "Error", MessageBoxButtons.OK);
    }
