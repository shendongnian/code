        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBox myCheckbox = (((sender as ToolStripDropDownItem).Owner as ContextMenuStrip).SourceControl as CheckBox);
            myCheckbox.Text = DateTime.Now.ToString();
        }
