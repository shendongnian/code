    bool isGivePermitProcessing = false;
    private void BtnGivePermit_Click(object sender, EventArgs e)
    {
        isGivePermitProcessing = true;
        try {
            ...
        } finally {
            isGivePermitProcessing = false;
        }
    }
