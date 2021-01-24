    private void BtnGivePermit_Click(object sender, EventArgs e)
    {
        BtnGivePermit.Enabled = false;
        try {
            ...
        } finally {
            BtnGivePermit.Enabled = true;
        }
    }
