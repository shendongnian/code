    protected void uxCloseDateCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        if (uxOwnershipCheckBox.Checked) //This is where your issue is..
        {
            DateTime dateTicketClosed = DateTime.ParseExact(uxDateTimeLocalTextbox.Text, "MM-dd-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }
    }
