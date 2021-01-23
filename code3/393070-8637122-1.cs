    public partial class Form2 : Form
    {
        // ...
        private void buttonCloseAll_Click( object sender, EventArgs args )
        {
            // Close Form2 _and_ return the abort result.
            DialogResult = DialogResult.Abort;
        }
    }
