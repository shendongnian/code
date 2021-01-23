    public class ChildForm
    {
        public event EventHandler SomeEvent;
    
        protected virtual void OnSomeEvent( EventArgs e )
        {
            EventHandler del = SomeEvent;
            if( del != null )
            {
                // fire the event
                del( this, e );
            }
        }
    
        private void someButton_Click( object sender, EventArgs e )
        {
            // for the sake of example, let's assume that you want
            // to notify listeners of "SomeEvent" when a button is clicked
            OnSomeEvent( this, EventArgs.Empty );
        }
    }
    
    public class MainForm : Form
    {
        private void ShowChildForm( )
        {
            using( ChildForm frm = new ChildForm() )
            {
                frm.SomeEvent += frm_SomeEvent;
                frm.ShowDialog();
            }
        }
    
        private void frm_SomeEvent( object sender, EventArgs e )
        {
            // this is where we handle the event "SomeEvent" that the 
            // child form fires when you need to communicate that something has happened.
            // now you may update the UI as needed and the ChildForm class does not have
            // to know anything about how the UI is actually implemented.
            // this is referred to as "loose coupling" and makes your code more maintainable.
            someCheckbox.Checked = true;
        }
    }
