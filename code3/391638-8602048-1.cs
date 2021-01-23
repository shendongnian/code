    public void btnCancel_Click(object sender, EventArgs e)
    {
        if(CancelClicked != null)
        {
            CancelClicked(this, e);
        }
    }
