       private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason.Equals(CloseReason.WindowsShutDown))
            {
               if (MessageBox.Show("You are closing this app.\n\nAre you sure you wish to exit ?", "Warning: Not Submitted", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == DialogResult.Yes)
                   return;    
               else    
                   e.Cancel = true;
            }
        }
