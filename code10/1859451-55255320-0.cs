    private void btnClose_Click(object sender, EventArgs e) {
      // On btnClose button click all we should do is to Close the form
      Close();
    }
    
    private void frminventory_FormClosing(object sender, FormClosingEventArgs e) {
      // If it's a user who closes the form...
      if (e.CloseReason == CloseReason.UserClosing) {
        // ...warn (s)he and cancel form closing if necessary
        e.Cancel = MessageBox.Show("Are You Sure You Want To Close This Form?", 
                                   "Close Application", 
                                    MessageBoxButtons.YesNo) != DialogResult.Yes;
      }
    }
