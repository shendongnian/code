    var maxEntries = 5;
    var totalEntries = 0;
    Hide();
    while (totalEntries < maxEntries)
    {
        DialogResult answer = 
            MessageBox.Show("Would you like to add an additional driver to policy?" 
                "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        if (answer == DialogResult.Yes)
        {
            new frmAdditionalDriver().ShowDialog();
        }
        else
        {
            new frmInsurancePolicy().ShowDialog();
        }
        totalEntries++;
    }
    Show();
