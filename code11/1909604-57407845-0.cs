    private void subScribeAllTextBoxClickEvents()
    {
      foreach(var ctrl in this.Controls)
      {
        var textBox = ctrl as TextBox;
        if(textBox != null)
        {
          textBox.Click += textBox_Click;
        }
      }
    }
    
    private void textBox_Click(object sender, EventArgs e)
    {
    
    }
