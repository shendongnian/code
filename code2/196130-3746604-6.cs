    private void chkOrderDate_CheckedChanged(object sender, EventArgs e)
    {
        if (chkOrderDate.Checked)
        {
            qFlag |= QueryFlag.OrderDate;
        }
        else
        {
            qFlag &= (~QueryFlag.OrderDate);
        }
    }
