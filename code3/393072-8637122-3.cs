    public partial class Form2 : Form
    {
        // ...
        private void buttonCloseAll_Click( object sender, EventArgs args )
        {
            // Close myself _and_ return the abort result to the caller.
            DialogResult = DialogResult.Abort;
        }
    }
