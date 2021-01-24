    protected void ButtonSend_Click(object sender, System.EventArgs e)
    {
    ....
      Utility.sendEmail(userEmail, SpellTextBoxNotify.Text, newlineToBR(TextBoxSubject.Text), ccClean);
    ...
    }
 
