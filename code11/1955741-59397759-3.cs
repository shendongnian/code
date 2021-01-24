    var maxEntries = 5;
    var totalEntries = 0;
    DialogResult answer = 
        MessageBox.Show("Would you like to add an additional driver to policy?",
            "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
    while (totalEntries < maxEntries && answer == DialogResult.Yes)
    {
        totalEntries++;
        if (answer == DialogResult.Yes)
        {
            Hide();
            new frmAdditionalDriver().ShowDialog();                   
        }
        answer = MessageBox.Show("Would you like to add an additional driver to policy?",
            "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
    }
    frmInsurancePolicy form = new frmInsurancePolicy();
    form.Show();
    this.Hide();
