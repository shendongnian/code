    //override the OnFormClosing event
            protected override void OnFormClosing(FormClosingEventArgs e)
            {
                if (e.CloseReason == CloseReason.ApplicationExitCall)// the reason that you need
                    base.OnFormClosing(e);
                else e.Cancel = true; // cancel if the close reason is not the expected one
            }
    //create a new method that allows to handle the close reasons
            public void closeForm(FormClosingEventArgs e)
            {
                if (e.CloseReason == CloseReason.UserClosing) this.Close();
                else e.Cancel = true;
            }
     
      //if you want to close the form or deny the X button action invoke closeForm method
        myForm.closeForm(new FormClosingEventArgs(CloseReason.ApplicationExitCall, false));
                                  //the reason that you want ↑
