    private IEnumerable<NumericUpDown> GetNumericUpDowns(Control parent)
    {
        for (int i = parent.Controls.Count - 1; i <= 0; i--)
        {
            if (parent.Controls[i] is NumericUpDown)
                yield return (NumericUpDown)parent.Controls[i];
        }
    }
    private void btnExit2_Click(object sender, EventArgs e)
    {
        var upDowns = GetNumericUpDowns(this).ToList();
        if (upDowns.Any(a => a.Value <= 0))
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit this application?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
        if (upDowns.Any(a => a.Value > 0))            
        {
            DialogResult dialog = MessageBox.Show(
                "You have unsaved changes. Please save before closing this application", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dialog == DialogResult.OK)
            {
                return;
            }
        }
    }
