    private void Form2_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (e.CloseReason == CloseReason.UserClosing) {
        DialogResult userAnswer = MessageBox.Show ("Do you wish to close ALL " + counterLabel.Text + " of the 'Form2' forms?", "Close ALL Forms?", 
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (userAnswer == DialogResult.No)
          e.Cancel = true;
      }
    }
