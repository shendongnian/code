        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateSettings())
            {
                SaveSettings();
                Close();
                DialogResult = DialogResult.OK;
            }
        }
