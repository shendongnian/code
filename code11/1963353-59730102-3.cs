        private void btn_Click(object sender, EventArgs e)
        {
            if (!pnlControls.Controls.Contains(YourUC.Instance))
            {
                pnlControls.Controls.Add(YourUC.Instance);
                YourUC.Instance.Dock = DockStyle.Fill;
                YourUC.Instance.BringToFront();                
            }
            else
            {
                YourUC.Instance.BringToFront();                
            }
        }
