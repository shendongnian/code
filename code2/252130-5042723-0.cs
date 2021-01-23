    private void EnableMenuItem(ToolStripMenuItem item, bool enabled)
        {
            this.BeginInvoke(new MethodInvoker(delegate()
            {
                item.Enabled = enabled;
            }
            ));
        }
