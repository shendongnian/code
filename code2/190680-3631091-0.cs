    public class MyForm : Form
    {
        private bool _ignoreTextChanged;
    
        private void listView1_SelectionChanged( object sender, EventArgs e )
        {
           _ingnoreTextChanged = true;
           textBoxPilot.Text = listView1.SelectedValue.ToString(); // or whatever
        }
    
        private void textBoxPilot_TextChanged( object sender, TextChangedEventArgs e )
        {
           if( _ignoreTextChanged )
           {
               _ignoreTextChanged = false;
               return;
           }
    
           // Do what you would normally do.
        }
    }
