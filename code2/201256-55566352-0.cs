    private void btnPrihlasenie_Click(object sender, EventArgs e)
    {
        if (IsAzetIdValid()) {
            errorProvider.SetError(tbAzetId, "");
        } else {
            errorProvider.SetError(tbAzetId, @"Nezadali ste Azet ID");
        }
    }
