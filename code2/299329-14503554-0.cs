        protected override void OnAfterInstall(IDictionary savedState)
        {
            // message box to test
            MessageBox.Show("test");
            Verify topmostForm = new Verify();
            topmostForm.BringToFront();
            topmostForm.TopMost = true;
            topmostForm.ShowDialog();
          //this line is missing in your code
           base.OnAfterInstall(savedState);
        }
