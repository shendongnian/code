        AdminControllerEventArgs e = new AdminControllerEventArgs();
        if (DeleteClick != null)
        {
            if (MessageBox.Show("Are you sure to save?", "Please Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DeleteClick(sender, e);
                if (adminControllerEventArgs.Success)
                {
                    MessageBox.Show("This record is saved successfully.");
                }
                else
                {
                    MessageBox.Show("This record is saved failed.");
                }
            }
        }
