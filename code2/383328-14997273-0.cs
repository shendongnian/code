    protected override void OnFormClosing(FormClosingEventArgs e)
            {            
                base.OnFormClosing(e);
                if (PreClosingConfirmation() == System.Windows.Forms.DialogResult.Yes)
                {
                    Dispose(true);
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            
            private DialogResult PreClosingConfirmation()
            {
                DialogResult res = System.Windows.Forms.MessageBox.Show(" Do you want to quit?          ", "Quit...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return res;
            }
