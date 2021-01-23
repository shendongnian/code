        private void LaunchForm(Form formToOpen)
        {
            try
            {
                if (formToOpen != null)
                {
                    if (Application.OpenForms.OfType<Form>().Count() > 0)
                    {
                        if (Application.OpenForms[formToOpen.Name].WindowState == FormWindowState.Minimized)
                        {
                            Application.OpenForms[formToOpen.Name].WindowState = FormWindowState.Normal;
                            Application.OpenForms[formToOpen.Name].BringToFront();
                        }
                        else
                        {
                            Application.OpenForms[formToOpen.Name].BringToFront();
                        }
                    }
                    else
                    {
                        Form formToLaunch;
                        formToLaunch = formToOpen;
                        formToLaunch.StartPosition = FormStartPosition.Manual;
                        formToLaunch.Location = new Point(this.Location.X + this.Width / 2 - formToLaunch.Width / 2, this.Location.Y + this.Height / 2 - formToLaunch.Height / 2);
                        formToLaunch.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("Unable to perform requested action: " + ex.Message.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
