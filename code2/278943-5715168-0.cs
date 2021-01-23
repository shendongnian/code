    public virtual void btnSave_Click(object sender, EventArgs e)
        {
            if (this.success)
                MessageBox.Show(MessageManager.SaveSuccess, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show(MessageManager.SaveFailed, "Fail to save", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }
