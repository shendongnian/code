    public void MyEventToCallForm() {
       var result = frmMain.Execute();
       if (result.Result = DialogResult.OK) {
           myTextBox.Text = result.Field1; // or something like that
       }
    }
