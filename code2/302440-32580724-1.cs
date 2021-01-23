    public class EntryForm: Form
    {
       public EntryForm()
       {
       }
       private void EntryTextBox_KeyDown(object sender, KeyEventArgs e)
       {
          if(e.KeyCode == Keys.Enter)
          {
             e.Handled = true;
             e.SuppressKeyPress = true;
             // do some stuff
      
          }
          else if(e.KeyCode == Keys.Escape)
          {
              e.Handled = true;
              e.SuppressKeyPress = true;
              // do some stuff
          }
       }
       private void EntryTextBox_KeyUp(object sender, KeyEventArgs e)
       {
          if(e.KeyCode == Keys.Enter)
          {
             // do some stuff
          }
          else if(e.KeyCode == Keys.Escape)
          {
             // do some stuff
          }
       }
    }
