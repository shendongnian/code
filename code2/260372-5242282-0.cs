    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                if (keyData == Keys.Delete)
                {
                    if(pictureBox1.Focus())
                    {
                        this.Controls.Remove(pictureBox1);
                    }
                    return true;
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }
