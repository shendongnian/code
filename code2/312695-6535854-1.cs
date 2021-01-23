    private void textBox1_Leave(object sender, System.EventArgs e)
    {
      if(textBox1.Text != "")
        btnCTimetablesOk.Visible = true;
      else
        btnCTimetablesOk.Visible = false;
    }
