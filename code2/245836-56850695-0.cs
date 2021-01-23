        Control _sourceControl = null;
        private void contextMenuStrip_Opened(object sender, EventArgs e)
        {
            _sourceControl = contextMenuStrip.SourceControl;
        }
        private void contextMenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem)sender;
            _sourceControl.Text = menuItem.Text;
            MessageBox.Show(menuItem.Name);
            MessageBox.Show(sourceControl.Name);
        }
