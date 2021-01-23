    DialogResult result = MessageBox.Show("Do You Really Want To Logout/Exit?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                }
