    private void checkValidaty()
        {
            if (!setting.checkLicence(settingInfo.validateCode))
            {
                if (MessageBox.Show("Do you want to enter new licence?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign) == DialogResult.No)
                {
                    Application.Exit();
                }
                else
                {
                    frmValidateNewLisence frm = new frmValidateNewLisence();
                    frm.ShowDialog();
                    this.checkValidaty();
                }
            }
        }
