    public class MainWindow : Window
    {
        public void ShowMyDialog()
        {
            // create the modal dialog
            ModalWindow window = new ModalWindow();
            // bind the event
            window.OnCallMyMethod += MyMethod;
            // show dialog
            window.ShowDialog();
        }
        private void MyMehod(object sender, EventArgs e)
        {
            // insert code here that should be triggered by the dialog.
        }
    }
---
    public class ModalWindow : Window
    {
        // declaration of event
        public event EventHandler OnCallMyMethod;
        // for example: when a button is clicked, it should trigger the event.
        public void Button1_Click(object sender, EventArgs e)
        {
            // raise the event.
            OnCallMyMethod?.Invoke(this, EventArgs.Empty);
        }
    }
