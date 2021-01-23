        delegate void ToolStripPrograssDelegate(int value);
        private void ToolStripPrograss(int value)
        {
            if (this.InvokeRequired)
            {
                ToolStripPrograssDelegate del = new ToolStripPrograssDelegate(ToolStripPrograss);
                this.Invoke(del, new object[] { value });
            }
            else
            {
                toolStripProgressBar1.Value = value; // Your thingy with the progress bar..
            }
        }
   
