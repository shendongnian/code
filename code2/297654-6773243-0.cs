    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form dummyForm = null;
            // Create a 'pseudo' invisible form that we make temporarily topmost
            dummyForm = new Form() { ShowInTaskbar = false, WindowState = FormWindowState.Minimized };
            dummyForm.Show();
            dummyForm.TopMost = true;
            dummyForm.TopMost = false;
            // Use the dummy form as our parent
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog(dummyForm); // First dialog
            // Do some stuff here...
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog(dummyForm); // Second dialog;
        }
    }
