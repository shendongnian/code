    double total = 0;
    try
    {
        foreach (GroupBox ctrl in this.Controls.OfType<GroupBox>()) //We get all of groupboxes.
        {
            foreach (CheckBox c in ctrl.Controls.OfType<CheckBox>()) //We get all of checkboxes which are in a groupbox that refered upper foreach loop's ctrl.One by one.
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
