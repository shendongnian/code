        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (CloseCancel()==false)
            {
                e.Cancel = true;
            };
        }
        public static bool CloseCancel()
        {
            const string message = "Are you sure that you would like to cancel the installer?";
            const string caption = "Cancel Installer";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }
