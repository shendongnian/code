    private bool CheckTextBox(TextBox tb)
    {
       if(string.IsNullOrEmpty(tb.Text))
       {
         MessageBox.Show("Textbox can't be empty!");
         return false;
       }
       return true;
    }
