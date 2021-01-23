    public partial class Form1 : Form
    {
        // ...
        private void callForm2()
        {
            var form2 = new Form2();
            if ( form2.ShowDialog( this )== DialogResult.Abort )
            {
                // Close myself if called form instructs me to close.
                Close();
            }
        }
    }
