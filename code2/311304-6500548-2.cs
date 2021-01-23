        delegate void ToolStripPrograssDelegate(int value);
        private void ToolStripPrograss(int value)
        {
            if (toolStrip1.InvokeRequired)
            {
                ToolStripPrograssDelegate del = new ToolStripPrograssDelegate(ToolStripPrograss);
                toolStrip1.Invoke(del, new object[] { value });
            }
            else
            {
                toolStripProgressBar1.Value = value; // Your thingy with the progress bar..
            }
        }
