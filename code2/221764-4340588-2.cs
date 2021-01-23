    private void m_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
       if (e.Control && e.KeyCode == Keys.C) 
       {
          //Grab selected text
          Clipboard.SetText(richTextBox1.SelectedText);
          string s = Clipboard.GetText();
          //Execute some action with the string
       }
    }
