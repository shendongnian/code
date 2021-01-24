    private void btnSave_Click(object sender, EventArgs e)
    {
        cstmAntraege jobStart = Application.OpenForms().OfType<cstmAntraege>();
        if(jobStart == null)
        {
            jobStart = new cstmAntraege();
            jobStart.Show();
        }
        string Anwender = "'" + txtUserID.Text + "', '" + txtVorname.Text + "', '" + txtNachname.Text + "', '" + txtEMail.Text + "', '" + txtFirma.Text + "'";
        Data.SetAnwender(Anwender); //here the string is transfered into the data class
        jobStart.AnwenderReload();  //and thats where i try to start the job in the other class where the listbox is
    }
