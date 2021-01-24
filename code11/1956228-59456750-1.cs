       private void ItemsCopyer_FormClosing(object sender, FormClosingEventArgs e)
           {
             System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        
            private void btnAbort_Click(object sender, EventArgs e)
            {
                shouldAbort = true;
                btnAbort.Enabled = false;
            }
