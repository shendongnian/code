    var maxEntries = 5;
    var totalEntries = 0;
    DialogResult answer = 
        MessageBox.Show("Would you like to add an additional driver to policy?",
            "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
    Hide();
    while (totalEntries < maxEntries && answer == DialogResult.Yes)
    {
        totalEntries++;
        if (answer == DialogResult.Yes)
        {
            new frmAdditionalDriver().ShowDialog();                   
        }
        answer = MessageBox.Show("Would you like to add an additional driver to policy?",
            "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
    }
    new frmInsurancePolicy().ShowDialog();
    Show();
