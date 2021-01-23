    public partial class MyForm : Form
    {
      private void MyForm_Load(object sender, EventArgs e)
      {
         ForceControlCreation(control1);
         ForceControlCreation(control2);
      }
      private void ForceControlCreation(IWin32Window control)
      {
        // Ensures that the subject control is created in the same thread as the parent 
        // form's without making it actually visible if not required. This will prevent 
        // any possible InvalidAsynchronousStateException, if the control is later 
        // invoked first from a background thread.
        var handle = control.Handle; 
      }
    }
