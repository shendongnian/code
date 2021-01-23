    private bool _isInButtonClick;
    private void button_Click(object sender, EventArgs e)
    {
          try
          {
              _isInButtonClick = true;
              //Changes the Text in the RichBox, EXAMPLE:
              richtTextBox.Text = "Now Changed and calling Method richTextBox_TextChanged";
          }
          finally
          {
              _isInButtonClick = false;
          }
    }
     private void richTextBox_TextChanged(object sender, EventArgs e)
     {
             if(_isInButtonClick)
             {
               //DO SOMETHING
             }
             else
             {
               //DO SOMETHING
             }
     }
