    public class MyForm : Form
    {
        // ...
    
        public void SafeClose()
        {
            // Make sure we're running on the UI thread
            if (this.InvokeRequired)
            {
                BeginInvoke(new Action(SafeClose));
                return;
            }
    
            // Close the form now that we're running on the UI thread
            Close();
        }
    
        // ...
    }
