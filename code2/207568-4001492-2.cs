       public UnhandledExceptionDlg()
        {
            // Add the event handler for handling UI thread exceptions to the event:
            Application.ThreadException += new ThreadExceptionEventHandler(ThreadExceptionFunction);
            // Set the unhandled exception mode to force all Windows Forms errors to go through our handler:
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            // Add the event handler for handling non-UI thread exceptions to the event:
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionFunction);
        }
        private void UnhandledExceptionFunction(Object sender, UnhandledExceptionEventArgs args)
        {
            // Suppress the Dialog in Debug mode:
            #if !DEBUG
            ShowUnhandledExceptionDlg((Exception)args.ExceptionObject);
            #endif
        }
        private void ShowUnhandledExceptionDlg(Exception e)
        {
            Exception unhandledException = e;
            if(unhandledException == null)
                unhandledException = new Exception("Unknown unhandled Exception was occurred!");
            UnhandledExDlgForm exDlgForm = new UnhandledExDlgForm();
            try
            {
                string appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
                exDlgForm.Text = appName;
                exDlgForm.labelTitle.Text = String.Format(exDlgForm.labelTitle.Text, appName);
                exDlgForm.checkBoxRestart.Text = String.Format(exDlgForm.checkBoxRestart.Text, appName);
                exDlgForm.checkBoxRestart.Checked = this.RestartApp;
                // Do not show link label if OnShowErrorReport is not handled
                exDlgForm.labelLinkTitle.Visible = (OnShowErrorReport != null);
                exDlgForm.linkLabelData.Visible = (OnShowErrorReport != null);
                // Disable the Button if OnSendExceptionClick event is not handled
                exDlgForm.buttonSend.Enabled = (OnSendExceptionClick != null);
                // Attach reflection to checkbox checked status
                exDlgForm.checkBoxRestart.CheckedChanged += delegate(object o, EventArgs ev)
                {
                    this._dorestart = exDlgForm.checkBoxRestart.Checked;
                };
                // Handle clicks on report link label
                exDlgForm.linkLabelData.LinkClicked += delegate(object o, LinkLabelLinkClickedEventArgs ev)
                {
                    if(OnShowErrorReport != null)
                    {
                        SendExceptionClickEventArgs ar = new SendExceptionClickEventArgs(true, unhandledException, _dorestart);
                        OnShowErrorReport(this, ar);
                    }
                };
                // Show the Dialog box:
                bool sendDetails = (exDlgForm.ShowDialog() == System.Windows.Forms.DialogResult.Yes);
                if(OnSendExceptionClick != null)
                {
                    SendExceptionClickEventArgs ar = new SendExceptionClickEventArgs(sendDetails, unhandledException, _dorestart);
                    OnSendExceptionClick(this, ar);
                }
            }
            finally
            {
                exDlgForm.Dispose();
            }
        }
